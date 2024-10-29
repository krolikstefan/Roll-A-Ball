using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject[] collectibles;
    public int score = 0;
    private int scoreToGet;
    private GameObject player;
    private MovementController controller;

   // private TextManager textManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<MovementController>();

        collectibles = GameObject.FindGameObjectsWithTag("point");
        scoreToGet = collectibles.Length;
        print(scoreToGet);
        controller.pickUpPoint += addPoint;

    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    private void addPoint()
    {
        score += 1;
        //textManager.updateScoreText();
        print(score);
    }

}
