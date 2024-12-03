using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemMono : MonoBehaviour
{
    public Item itemData;

    public int id;
    public Categories category;
    public Colors color;
    public string itemName;
    public Sprite sprite;
    void Awake()
    {
        SetData();
    }
    void SetData()
    {
        itemName = itemData.name;
        id = itemData.id;
        color = itemData.color;
        category = itemData.category;
        sprite = itemData.icon;
    }


}
