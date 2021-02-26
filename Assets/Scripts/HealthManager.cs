using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    int health;
    public Text healthText;
    public GameObject gameOverPanel;

    private void Start()
    {
        health = 100;
        healthText.text = health.ToString();
        gameOverPanel.SetActive(false);
    }
    void Update()
    {
        
    }
    public void Damage(int damageValue)
    {
        health -= damageValue;
        HealthCheck();
        healthText.text = health.ToString();
    }

    void HealthCheck()
    {
        if (health <= 0)
        {
            health = 0;
            gameOverPanel.SetActive(true);
        }
        if (health >= 100)
        {
            health = 100;
        }
    }

    void PlayerDies()
    { 
        // restart the game 
        // trigger death animation 
        // trigger death sound fx
        // display final score

    }
}
