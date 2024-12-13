using UnityEngine;

public abstract class ConsumablesObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Consumables;
    }

    private void AddEffect()
    {

    }

}
