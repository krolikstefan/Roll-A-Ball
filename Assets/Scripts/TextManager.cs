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

        controller.pickUpPoint += updateScoreText;

    }

    public void updateScoreText()
    {

        scoreTextComp.text = "Score: " + managerScript.score;
    }

    public void winInfoText()
    {
        infoTextA.text = "You win! c:";
    }
}
