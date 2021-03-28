using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    ScoreManager scoreManager;
    AudioManager audioManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            scoreManager.ObjectCollected();
            audioManager.PlaySound("StarCollected", true);
            Destroy(gameObject);
        }
    }
}