using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int Score;

    public void ObjectCollected()
    {
        Score++;

        Debug.Log("Current Score: " + Score);

    }   


}
