using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{

    public void RestartScene()
    {
        SceneManager.LoadScene(0); // restarts level 1       
    }

}
