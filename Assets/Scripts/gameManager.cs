using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Dictionary<int, int> levelScores = new Dictionary<int, int>();
    public static GameManager gameManager;

    public GameObject[] collectibles;
    [HideInInspector] public int score = 0;
    private int scoreToGet;
    private GameObject player;
    private GameObject manager;
    private MovementController controller;
    private TextManager textManager;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeSceneData();
    }

    private void InitializeSceneData()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            controller = player.GetComponent<MovementController>();
            controller.pickUpPoint -= AddPoint;
            controller.pickUpPoint += AddPoint;
        }

        manager = GameObject.Find("TextManager");
        if (manager != null)
        {
            textManager = manager.GetComponent<TextManager>();
        }

        collectibles = GameObject.FindGameObjectsWithTag("point");
        scoreToGet = collectibles.Length;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        score = levelScores.ContainsKey(currentSceneIndex) ? levelScores[currentSceneIndex] : 0;

        if (textManager != null)
        {
            textManager.UpdateScoreText();
        }
    }

    void AddPoint()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (!levelScores.ContainsKey(currentSceneIndex))
        {
            levelScores[currentSceneIndex] = 0;
        }
        levelScores[currentSceneIndex]++;
        score = levelScores[currentSceneIndex];

        if (textManager != null)
        {
            textManager.UpdateScoreText();
        }

        StartCoroutine(WaitForLoad());
    }

    IEnumerator WaitForLoad()
    {
        if (score == scoreToGet)
        {
            textManager.WinInfoText();
            yield return new WaitForSecondsRealtime(3);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
