using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private GameObject player;
    private MovementController controller;
    private gameManager managerScript;
    private GameObject scoreText;
    private Text scoreTextComp;
    private GameObject infoText;
    private Text infoTextA;

    private GameObject teleport;
    private Teleporter teleporter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<MovementController>();

        managerScript = gameObject.AddComponent<gameManager>();

        scoreText = GameObject.Find("scoreText");

        infoText = GameObject.Find("infoText");
        scoreTextComp=scoreText.GetComponent<Text>();
        infoTextA = infoText.GetComponent<Text>();

        teleport = GameObject.Find("teleporter1");
        teleporter = teleport.GetComponent<Teleporter>();

        controller.pickUpPoint += updateScoreText;
        controller.openDoor += openDoorText;
        controller.closeDoor += clearDoorText;

        teleporter.onTeleport += standOnTeleport;

    }

    public void updateScoreText()
    {

        scoreTextComp.text = "Score: " + managerScript.score;
    }

    public void winInfoText()
    {
        infoTextA.text = "You win! c:";
    }
    private void openDoorText()
    {
        infoTextA.text = "Press F to open a door";
    }
    private void clearDoorText()
    {
        infoTextA.text = ""; 
    }
    private void standOnTeleport()
    {
        infoTextA.text = "Please wait, teleport is loading";
    }
}
