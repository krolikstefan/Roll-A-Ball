using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //singleton
    public static GameManager instance;


    public GameObject[] collectibles;
    public int score = 0;
    private int scoreToGet;
    private GameObject player;
    private GameObject manager;
    private MovementController controller;

    private TextManager textManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
           Destroy(gameObject);
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<MovementController>();

        collectibles = GameObject.FindGameObjectsWithTag("point");
        scoreToGet = collectibles.Length;

        manager = GameObject.Find("GameManager");
        textManager=manager.GetComponent<TextManager>();


        //print(scoreToGet);
        controller.pickUpPoint += AddPoint;
        
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    private void AddPoint()
    {
        score += 1;
        textManager.UpdateScoreText();
        print(score);

        if (score == scoreToGet && SceneManager.GetActiveScene().buildIndex.Equals(3))
        {
            textManager.WinInfoText();
            SceneManager.LoadScene(4);
        }

        else if (score == scoreToGet)
        {
            textManager.WinInfoText();
            SceneManager.LoadScene(1);
        }

    }

}
