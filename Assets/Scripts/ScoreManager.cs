using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    private static ScoreManager Instance { get { return _instance; } }


    private int Score;
    public Text scoreText;

    private void Awake()
    {
        if (_instance !=null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }     
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

    public int ReturnFinalScore()
    {
        return Score;
    }

}