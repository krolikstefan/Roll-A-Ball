using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NPC", menuName = "Scriptable Objects/NPC")]
public class NPC : ScriptableObject
{
    public string npcName;
    public List<ItemObject> likedGifts = new List<ItemObject>();
    public List<ItemObject> neutralGifts = new List<ItemObject>();
    public List<ItemObject> dislikedGifts = new List<ItemObject>();
}
