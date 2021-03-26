using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int Score;
    public Text scoreText;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }


    public void ObjectCollected()
    {
        Score++;
        scoreText.text = Score.ToString();

    }

    private void Update()
    {
        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
            scoreText.text = Score.ToString();
        }
    }

}