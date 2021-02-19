using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int Score;
    public Text scoreText;

    public void ObjectCollected()
    {
        Score++;
        scoreText.text = Score.ToString();    
    }   

}
