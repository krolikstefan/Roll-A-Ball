using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class ItemDisplay : MonoBehaviour
{
    public int itemIndex;
    public Image itemSprite;

    public void UpdateItemDisplay(Sprite newSprite, int newIndex)
    {

     itemSprite.sprite = newSprite;
     itemIndex = newIndex;

    }


}
