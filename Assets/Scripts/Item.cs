using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "Scriptable Objects/item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public Categories category;
    public Colors color;


    public Sprite icon;
    public GameObject model;

}

