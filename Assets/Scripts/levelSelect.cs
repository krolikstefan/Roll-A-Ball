using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public void Level1()
    {
        SceneManager.LoadScene(2);
    }
    public void Level2()
    {
        SceneManager.LoadScene(3);
    }
    public void Level3()
    {
        SceneManager.LoadScene(4);
    }
}
