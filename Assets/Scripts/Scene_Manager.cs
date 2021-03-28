using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public int nextSceneNumber;
    int finalLevel = 2;
    int currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0); // restarts level 1       
    }


    public void NextLevel()
    {
        SceneManager.LoadScene(nextSceneNumber);
    }
    public void NextLevel(int _delay)
    {
        Invoke(nameof(SceneLoadDelay), _delay);
    }

    void SceneLoadDelay()
    {
        SceneManager.LoadScene(nextSceneNumber);
    }
    public bool IsCurrentSceneFinal()
    {
        if (currentScene == finalLevel)
        {
            return true;
        }
        else
        {
            return false;
        }

    }


}