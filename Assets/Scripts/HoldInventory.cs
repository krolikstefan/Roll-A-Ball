using System;
using UnityEngine;

public class HoldInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public int whatItemSelected;
    public bool isItemSelected = false;
    private bool isAdded = false;
    public static bool iWantToPickUpThisItem = false;
    private bool isPlayerInTrigger = false;
    private NPCController npcInventory;

    public event Action iWantToPickUpOrAmINot;
    public event Action notAnymore;
    public event Action giveItem;
    public event Action itemGiven;


    public void OnTriggerStay(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            isPlayerInTrigger = true;
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

        if (other.tag == "NPC")
        {
            giveItem?.Invoke();
            isPlayerInTrigger = true;
            npcInventory = other.GetComponent<NPCController>();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        notAnymore?.Invoke();
        isPlayerInTrigger = false;

        if (other.tag == "NPC")
        {
            npcInventory = null;
        }
    }

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
    }

    public void DropItemFromInventory()
    {
        if (!isItemSelected)
            return;

        InventorySlot selectedSlot = inventory.GetSelectedItem();

        if (inventory.DropItem(selectedSlot.item, 1))
        {
            SpawnDroppedItem(selectedSlot.item);

            if (inventory.container.Count <= whatItemSelected)
            {
                isItemSelected = false;
            }
        }
    }

    private void SpawnDroppedItem(ItemObject itemToDrop)
    {
        if (itemToDrop.inGamePrefab != null)
        {
            Vector3 dropPosition = transform.position;
            dropPosition += transform.forward * 1.5f;
            dropPosition.y = 0.0f;

            GameObject droppedItem = Instantiate(itemToDrop.inGamePrefab, dropPosition, Quaternion.identity);

            if (droppedItem.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.AddForce(transform.forward * 0.5f, ForceMode.Impulse);
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i <= 9; i++)
        {
            if (Input.GetKeyDown(i == 0 ? KeyCode.Alpha0 : KeyCode.Alpha1 + (i - 1)))
            {
                whatItemSelected = i == 0 ? 9 : i - 1;
                SelectInventoryItem();
                break;
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && isPlayerInTrigger)
        {
            iWantToPickUpThisItem = true;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            DropItemFromInventory();
        }

        if (Input.GetKeyDown(KeyCode.G) && isPlayerInTrigger && npcInventory != null)
        {
            inventory.TransferItemToNPC(npcInventory.inventory);
            itemGiven?.Invoke();
        }
    }

    private void SelectInventoryItem()
    {
        if (inventory.SelectItem(whatItemSelected))
        {
            InventorySlot selectedSlot = inventory.GetSelectedItem();
            if (selectedSlot != null)
            {
                isItemSelected = true;
            }
        }
        else
        {
            isItemSelected = false;
        }
    }
}
