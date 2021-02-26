using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    int health;
    public Text healthText;
    public GameObject gameOverPanel;
    public GameObject damageOverlay;

    float overlayStartTime;
    float overlayDuration;
    bool displayOverlay;

    private void Start()
    {
        health = 100;
        healthText.text = health.ToString();
        gameOverPanel.SetActive(false);
        damageOverlay.SetActive(false);

    }
    void Update()
    {        
        
    }
    public void Damage(int damageValue)
    {
        health -= damageValue;
        HealthCheck();
        healthText.text = health.ToString();

        damageOverlay.SetActive(true); // enables damage overlay
        Invoke(nameof(DisableOverlay), 0.5f); // disables it after 1/2 sec
    }

    void HealthCheck()
    {
        if (health <= 0)
        {
            health = 0;
            damageOverlay.SetActive(false);// disables  damage overlay
            gameOverPanel.SetActive(true); // anables game over panel
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

    void DisableOverlay()
    {
        damageOverlay.SetActive(false);
    }
}
