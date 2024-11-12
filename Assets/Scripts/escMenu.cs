using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject escMenuObject;
    private Canvas canvas;

    private void Start()
    {
        escMenuObject = GameObject.Find("EscMenu");
        canvas = escMenuObject.GetComponent<Canvas>();
        canvas.enabled = false;

    }
    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void Resume()
    {
        canvas.enabled = false;
        Time.timeScale = 1f;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.enabled)
            {
                Resume();
            }
            else
            {
                canvas.enabled = true;
                Time.timeScale = 0f;
            }
        }
    }
}
