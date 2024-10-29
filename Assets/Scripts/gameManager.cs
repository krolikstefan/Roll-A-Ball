using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject[] collectibles;
    private int scoreToGet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collectibles = GameObject.FindGameObjectsWithTag("point");
        scoreToGet = collectibles.Length;
        print(scoreToGet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
