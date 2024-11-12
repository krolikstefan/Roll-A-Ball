using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private GameObject player;
    private MovementController controller;
    private GameManager managerScript;
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

        managerScript = gameObject.AddComponent<GameManager>();

        scoreText = GameObject.Find("scoreText");

        infoText = GameObject.Find("infoText");
        scoreTextComp=scoreText.GetComponent<Text>();
        infoTextA = infoText.GetComponent<Text>();

        teleport = GameObject.Find("teleporter1");
        teleporter = teleport.GetComponent<Teleporter>();

        controller.pickUpPoint += UpdateScoreText;
        controller.openDoor += OpenDoorText;
        controller.closeDoor += ClearDoorText;

        teleporter.onTeleport += StandOnTeleport;

    }

    public void UpdateScoreText()
    {

        scoreTextComp.text = "Score: " + managerScript.score;
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
