using Unity.VisualScripting;
using UnityEngine;

public class HoldInventory : MonoBehaviour
{
    public InventoryObject inventory;


    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item,1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
        inventory.inventorySpace = 5;
    }
}
