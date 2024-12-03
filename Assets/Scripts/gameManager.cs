using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private void Awake()
    {

        if (gameManager == null)
        {
            gameManager = this;
        }

        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public GameObject[] collectibles;
    [HideInInspector] public int score = 0;
    private int scoreToGet;
    private GameObject player;
    private GameObject manager;
    private MovementController controller;

    private TextManager textManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<MovementController>();

        collectibles = GameObject.FindGameObjectsWithTag("point");
        scoreToGet = collectibles.Length;

        manager = GameObject.Find("TextManager");
        textManager=manager.GetComponent<TextManager>();


        controller.pickUpPoint += AddPoint;
        
    }


    private void AddPoint()
    {
        score += 1;
        textManager.UpdateScoreText();
        StartCoroutine(WaitForLoad());

    }
    IEnumerator WaitForLoad()
    {
        if (score == scoreToGet && SceneManager.GetActiveScene().buildIndex.Equals(3))
        {
            textManager.WinInfoText();
            yield return new WaitForSecondsRealtime(3);
            SceneManager.LoadScene(4);
        }
        else if (score == scoreToGet)
        {
            textManager.WinInfoText();
            yield return new WaitForSecondsRealtime(3);
            SceneManager.LoadScene(1);
        }
    }

}
