using UnityEngine;

[CreateAssetMenu(fileName = "GemsObject", menuName = "InventorySystem/Items/GemsObject")]
public class GemsObject : ItemObject
{
    public int growTime;
    public int price;
    public int quantity;

    private void Awake()
    {
        type = ItemType.Gems;
    }
}
