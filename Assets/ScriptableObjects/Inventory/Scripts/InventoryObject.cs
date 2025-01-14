using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "InventoryObject", menuName = "InventorySystem/InventoryObject")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> container = new List<InventorySlot>();
    public int maxInventoryCapacity = 10;
    private bool hasItem;

    public InventorySlot selectedSlot;
    public event Action<InventorySlot> OnItemSelected;


    public bool AddItem(ItemObject itemToAdd, int howManyToAdd)
    {
        hasItem = false;
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item == itemToAdd)
            {
                container[i].AddAmount(howManyToAdd);
                hasItem = true;
                return true;
            }
        }

        if (!hasItem && container.Count < maxInventoryCapacity)
        {
            container.Add(new InventorySlot(itemToAdd, howManyToAdd));
            return true;
        }
        else
        {
            Debug.LogWarning("Cannot add new item. Inventory is full.");
            return false;
        }
    }

    public bool DropItem(ItemObject itemToDrop, int howManyToDrop)
    {
        if (itemToDrop == null || howManyToDrop <= 0)
            return false;

        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item == itemToDrop)
            {
                if (container[i].amount < howManyToDrop)
                    return false;

                container[i].amount -= howManyToDrop;
                if (container[i].amount == 0)
                {
                    if (selectedSlot == container[i])
                        selectedSlot = null;

                    container.RemoveAt(i);
                }

                return true;
            }
        }
        return false;
    }
    public bool SelectItem(int slotIndex)
    {
        if (container == null || container.Count == 0)
        {
            return false;
        }

        if (slotIndex < 0 || slotIndex >= container.Count)
        {
            selectedSlot = null;
            return false;
        }
        selectedSlot = container[slotIndex];
        OnItemSelected?.Invoke(selectedSlot);
        return true;
    }

    public InventorySlot GetSelectedItem()
    {
        return selectedSlot;
    }

}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;

    public InventorySlot(ItemObject itemInSlot, int howMany)
    {
        item = itemInSlot;
        amount = howMany;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }


}
