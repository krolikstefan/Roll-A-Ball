using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable Objects/Inventory")]
public class Inventory : ScriptableObject
{
    public List<ItemInstance> items = new();
    private int maxItems = 6;


    //events
    public event Action noSpaceInInventory;

    public bool AddItems(ItemInstance item)
    {

        for(int i = 0;i<items.Count;i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                return true;
            }
        }

        if (items.Count < maxItems)
        {
            items.Add(item);
            return true;
        }
        else
        {
            noSpaceInInventory();
            return false;
        }


        
    }

}
