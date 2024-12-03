using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public ItemDisplay[] itemsToDisplay; 

    void Update()
    {
        
    }

    void UpdateInventory()
    {
        for (int i = 0; i < itemsToDisplay.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                itemsToDisplay[i].gameObject.SetActive(true);
                itemsToDisplay[i].UpdateItemDisplay(inventory.items[i].itemToAdd.icon, i);
            }
            else
            {
                itemsToDisplay[i].gameObject.SetActive(false);
            }
        }

    }


    public void DropItem(int itemIndex)
    {
        GameObject droppedItem = new GameObject();
        droppedItem.AddComponent<Rigidbody>();
        //droppedItem.AddComponent<InstanceItemContainer>().item
    }
}
