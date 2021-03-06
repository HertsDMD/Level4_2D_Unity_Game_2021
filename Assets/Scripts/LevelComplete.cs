﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{

    public GameObject levelCompleteText;
    Scene_Manager sceneManager;
    ScoreManager scoreManager;

    GameObject RestartButton;

    // Start is called before the first frame update
    void Start()
    {
        levelCompleteText.SetActive(false);
        sceneManager = FindObjectOfType<Scene_Manager>();
        scoreManager = FindObjectOfType<ScoreManager>();

        RestartButton = GameObject.Find("RestartButton");
        if (RestartButton !=null)
        {
        RestartButton.SetActive(false);
        }
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelCompleteText.SetActive(true);
            Invoke(nameof(nextScene), 1);
        }
    }
    void nextScene()
    {
        if (sceneManager.IsCurrentSceneFinal())
        {
            FinalLevel();
        }
        else
        {
            sceneManager.NextLevel();
        }
    }

    private void FinalLevel()
    {
        levelCompleteText.SetActive(true);
        Text finalScore = levelCompleteText.GetComponentInChildren<Text>();
        finalScore.text = "Final Score: " + scoreManager.ReturnFinalScore().ToString();

        if (RestartButton != null)
        {
            RestartButton.SetActive(true);

        }
    }
}