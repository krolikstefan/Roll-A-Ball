using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryObject", menuName = "InventorySystem/InventoryObject")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> container = new List<InventorySlot>();
    public int maxInventoryCapacity = 6;
    private bool hasItem;
    public void AddItem(ItemObject itemToAdd, int howManyToAdd)
    {
        hasItem = false;
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item == itemToAdd)
            {
                container[i].AddAmount(howManyToAdd);
                hasItem = true;
                return;
            }
        }

       if (!hasItem&&container.Count < maxInventoryCapacity)
        {
            container.Add(new InventorySlot(itemToAdd, howManyToAdd)); 
        }
        else
        {
            Debug.LogWarning("Cannot add new item. Inventory is full.");
        }
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
