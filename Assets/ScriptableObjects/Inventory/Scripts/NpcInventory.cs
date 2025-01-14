using UnityEngine;

public class NpcInventory : MonoBehaviour
{
    public InventoryObject inventory;
    private GameObject player;
    private MovementController movementController;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movementController = player.GetComponent<MovementController>();
    }

    public void ReceiveGift()
    {

    }
}
