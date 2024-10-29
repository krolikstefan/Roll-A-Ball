using UnityEngine;
using UnityEngine.UI;

public class ShowScoreText : MonoBehaviour
{
    private GameObject player;
   // private MovementController controller = new MovementController();
    public Text scoreText;
    private int showScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //player = GetComponent<>;
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //scoreText = Text.FindGameObjectWithTag("scoreText");
        //controller.pickUpPoint += UpdateScoreText();
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<MovementController>();
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
    private void UpdateScoreText()
    {
       
        //scoreText.text = "Score: " + player.score;
    }

}
