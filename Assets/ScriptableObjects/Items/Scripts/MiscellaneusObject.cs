using UnityEngine;

[CreateAssetMenu(fileName = "NewMiscellaneusObject", menuName = "InventorySystem/Items/Miscellaneus")]
public class MiscellaneusObject : ItemObject
{

    public void Awake()
    {
        type = ItemType.Miscellaneous;
    }

}
