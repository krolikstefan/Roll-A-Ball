using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    [SerializeField] private NPC npc;
    private GameObject player;
    public InventoryObject inventory;
    private HoldInventory playerInventory;
    private GameObject affectionImage;
    private Image affectionImageA;

    private List<ItemObject> likedGiftsNpc = new List<ItemObject>();
    private List<ItemObject> neutralGiftsNpc = new List<ItemObject>();
    private List<ItemObject> dislikedGiftsNpc = new List<ItemObject>();
    private float affectionPoints = 20;

    [SerializeField] private Sprite dislikeSprite;
    [SerializeField] private Sprite neutralSprite;
    [SerializeField] private Sprite likeSprite;


    private void Start()
    {
        likedGiftsNpc = npc.likedGifts;
        neutralGiftsNpc = npc.neutralGifts;
        dislikedGiftsNpc = npc.dislikedGifts;

        player = GameObject.FindGameObjectWithTag("Player");
        playerInventory = player.GetComponent<HoldInventory>();

        affectionImage = GameObject.Find("AffectionImage");
        affectionImageA = affectionImage.GetComponent<Image>();

        playerInventory.itemGiven += ItemReceived;
    }

    private void ItemReceived()
    {
        CheckItems();
        UpdateAffectionImage();
    }



    private void CheckItems()
    {
        foreach (InventorySlot itemInInventory in inventory.container)
        {
            if (likedGiftsNpc.Contains(itemInInventory.item))
            {
                affectionPoints += 20;
            }
            if (neutralGiftsNpc.Contains(itemInInventory.item))
            {
                affectionPoints += 10;
            }
            if (dislikedGiftsNpc.Contains(itemInInventory.item))
            {
                affectionPoints -= 10;
            }
        }

        if (affectionPoints < -30)
        {
            affectionPoints = -30;
        }
        else if (affectionPoints > 80)
        {
            affectionPoints = 80;
        }

        print(affectionPoints);
        inventory.container.Clear();
    }

    private void UpdateAffectionImage()
    {
        if (affectionImage != null)
        {
            if (affectionPoints < 0)
            {
                affectionImageA.sprite = dislikeSprite;
            }
            else if (affectionPoints >= 0 && affectionPoints < 30)
            {
                affectionImageA.sprite = neutralSprite; ;
            }
            else if (affectionPoints >= 50)
            {
                affectionImageA.sprite = likeSprite;
            }
        }
    }

}
