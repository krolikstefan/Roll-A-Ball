using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private GameObject player;
    private MovementController controller;
    private GameObject infoText;
    private GameObject teleport;
    private Teleporter teleporter;


    private GameObject scoreText;
    private Text scoreTextComp;
    private Text infoTextA;

    private HoldInventory inventory;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<MovementController>();


        scoreText = GameObject.Find("scoreText");

        infoText = GameObject.Find("infoText");
        if (scoreText != null)
        {
            if (scoreTextComp!=null)
            {
                scoreTextComp = scoreText.GetComponent<Text>();
            }
        }
        infoTextA = infoText.GetComponent<Text>();

        
        teleport = GameObject.Find("Teleporter1");
        if (teleport != null)
        {
            teleporter = teleport.GetComponent<Teleporter>();
        }

        inventory=player.GetComponent<HoldInventory>();

        controller.pickUpPoint += UpdateScoreText;
        controller.openDoor += OpenDoorText;
        controller.closeDoor += ClearInfoText;

        if (teleport != null)
        {
            teleporter.onTeleport += StandOnTeleport;
        }

        inventory.iWantToPickUpOrAmINot += PickUpText;
        inventory.notAnymore += ClearInfoText;

        inventory.giveItem += GiveText;


    }

    public void UpdateScoreText()
    {

        scoreTextComp.text = "Score: " + GameManager.gameManager.score;
    }

    public void WinInfoText()
    {
        infoTextA.text = "You win! c:";
    }
    private void OpenDoorText()
    {
        infoTextA.text = "Press F to open a door";
    }
    private void PickUpText()
    {
        infoTextA.text = "Press F to pick up this item";
    }
    private void GiveText()
    {
        infoTextA.text = "Press G to give gift to this character";
    }
    private void ClearInfoText()
    {
        infoTextA.text = ""; 
    }
    private void StandOnTeleport()
    {
        infoTextA.text = "Please wait, teleport is loading";
    }

}
