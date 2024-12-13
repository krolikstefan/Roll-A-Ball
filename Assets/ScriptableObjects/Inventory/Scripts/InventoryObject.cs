using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryObject", menuName = "InventorySystem/InventoryObject")]
public class InventoryObject : ScriptableObject
{

    public List<InventorySlot> container = new List<InventorySlot>();
    public int inventorySpace = 5;

    public void AddItem(ItemObject itemToAdd, int howManyToAdd)
    {
        bool hasItem = false;
        for (int i = 0; i<container.Count; i++)
        {
            if (container[i].item == itemToAdd)
            {
                container[i].AddAmount(howManyToAdd);
                hasItem = true;
                break;
            }
        }
        if (!hasItem&&container.Count<inventorySpace)
        {
            container.Add(new InventorySlot(itemToAdd, howManyToAdd));
            //inventorySpace--;
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