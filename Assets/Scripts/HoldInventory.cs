using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class HoldInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public int whatItemSelected;
    public bool isItemSelected=false;
    private bool isAdded=false;
    private bool iWantToPickUpThisItem = false;

    public event Action iWantToPickUpOrAmINot;
    public event Action notAnymore;
    public event Action itemSelectedNumber;

    public void OnTriggerStay(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            iWantToPickUpOrAmINot?.Invoke();
            if (iWantToPickUpThisItem)
            {
                isAdded = inventory.AddItem(item.item, 1);

                if (isAdded)
                {
                    Destroy(other.gameObject);
                    notAnymore?.Invoke();
                }
            }
            iWantToPickUpThisItem = false;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        var item = other.GetComponent<Item>();
        if(item)
        {
            notAnymore?.Invoke();
        }
    }

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            whatItemSelected = 0; 
            SelectInventoryItem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            whatItemSelected = 1;
            SelectInventoryItem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            whatItemSelected = 2;
            SelectInventoryItem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            whatItemSelected = 3;
            SelectInventoryItem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            whatItemSelected = 4;
            SelectInventoryItem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            whatItemSelected = 5;
            SelectInventoryItem();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            iWantToPickUpThisItem = true;
        }
    }
    private void SelectInventoryItem()
    {
        if (inventory.SelectItem(whatItemSelected))
        {
            InventorySlot selectedSlot = inventory.GetSelectedItem();
            if (selectedSlot != null)
            {
                Debug.Log($"Selected Item: {selectedSlot.item.name}, Amount: {selectedSlot.amount}");
                isItemSelected = true;
                itemSelectedNumber();
            }
        }
        else
        {
            isItemSelected = false;
        }
    }

}
