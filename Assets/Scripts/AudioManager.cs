using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;
    private AudioSource audioSource;
    private void Awake()
    {

        if (audioManager == null)
        {
            audioManager = this;
        }

        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager.audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
