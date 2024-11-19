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
    public Vector3 itemTransform;
    void Awake()
    {
        setData();
    }
    void setData()
    {
        //itemData.thisGameObject = gameObject;
        itemName = itemData.name;
        id = itemData.id;
        color = itemData.color;
        category = itemData.category;
        itemTransform = gameObject.transform.localScale;
    }


}
