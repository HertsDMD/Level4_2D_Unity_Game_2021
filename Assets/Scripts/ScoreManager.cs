using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    public static ScoreManager Instance { get { return _instance; } }

    bool sceneLoaded;
   
    private int Score;
    Text scoreText;
    private int currentScene;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        
        else
        {
           _instance = this;
           DontDestroyOnLoad(this);               
            
        }

    }
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        currentScene = SceneManager.GetActiveScene().buildIndex;

        if (scoreText != null)
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
            scoreText.text = Score.ToString();
        }               

    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 0)
        {
            Score = 0;
        }
        else
        {        
           // Debug.Log("scene changed to: " + currentScene.ToString());
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();

            scoreText.text = Score.ToString();
            sceneLoaded = true;
        }
       
    }
    private void LateUpdate()
    {
        if (scoreText != null && sceneLoaded)
        {
            scoreText.text = Score.ToString();
            sceneLoaded = false;
        }
    }

   

    public void ObjectCollected()
    {
        Score++;
        if (scoreText != null)
        {
            scoreText.text = Score.ToString();
        }

    }
    

    public int ReturnFinalScore()
    {
        return Score;     
        
    }

}