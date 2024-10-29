using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private GameObject player;
    private MovementController controller;
    private GameObject manager;
    private gameManager managerScript;
    private GameObject scoreText;
    private Text scoreTextComp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<MovementController>();

        manager = GameObject.Find("GameManager");
        managerScript = gameObject.AddComponent<gameManager>();

        scoreText = GameObject.Find("scoreText");
        scoreTextComp=scoreText.GetComponent<Text>();

        controller.pickUpPoint += updateScoreText;

    }

    private void updateScoreText()
    {

        scoreTextComp.text = "Score: " + managerScript.score;
    }

    private void updateInfoText()
    {

    }
}
