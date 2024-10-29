using UnityEngine;

public class WinCheck : MonoBehaviour
{
    private GameObject player;
    private MonoBehaviour playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<MonoBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
