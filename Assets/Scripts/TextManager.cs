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



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<MovementController>();


        scoreText = GameObject.Find("scoreText");

        infoText = GameObject.Find("infoText");
        scoreTextComp=scoreText.GetComponent<Text>();
        infoTextA = infoText.GetComponent<Text>();

        teleport = GameObject.Find("Teleporter1");
        teleporter = teleport.GetComponent<Teleporter>();

        controller.pickUpPoint += UpdateScoreText;
        controller.openDoor += OpenDoorText;
        controller.closeDoor += ClearDoorText;

        teleporter.onTeleport += StandOnTeleport;



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
    private void ClearDoorText()
    {
        infoTextA.text = ""; 
    }
    private void StandOnTeleport()
    {
        infoTextA.text = "Please wait, teleport is loading";
    }

}
