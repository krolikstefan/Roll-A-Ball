using Unity.VisualScripting;
using UnityEngine;

public class HoldInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public int whatItemSelected;
    public bool isItemSelected=false;
    private bool isAdded=false;
    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            isAdded=inventory.AddItem(item.item, 1);

            if (isAdded)
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
        //inventory.inventorySpace = 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            whatItemSelected = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            whatItemSelected=2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)) { 
            whatItemSelected=3; 
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            whatItemSelected=4;
        }
        if( Input.GetKeyDown(KeyCode.Alpha5))
        {
            whatItemSelected=5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            whatItemSelected=6;
        }
        print(whatItemSelected);
    }

}
