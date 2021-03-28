using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    int health = 100;
    public Text healthText;
    public GameObject gameOverPanel;
    public GameObject damageOverlay;
    readonly float overlayStartTime;
    readonly float overlayDuration;
    readonly bool displayOverlay;

    PlayerMove playerMove;
    Scene_Manager sceneManager;

    private void Start()
    {
        playerMove = FindObjectOfType<PlayerMove>();
        health = playerHealth;
        gameOverPanel.SetActive(false);
        damageOverlay.SetActive(false);
        sceneManager = FindObjectOfType<Scene_Manager>();

    }

    public bool FullHealth = true;
    bool playerDead;
    private int playerHealth
    {
        get { return health; }
        set
        {
            health = value;
            FullHealth = false;

            if (health <= 0)
            {
                health = 0;
                PlayerDies();
            }
            else if (health >= 100)
            {
                health = 100;
                FullHealth = true;
            }
            healthText.text = health.ToString();
        }
    }

    public void Damage(int damageValue)
    {
        if (!playerDead)
        {            
            playerHealth -= damageValue;
            damageOverlay.SetActive(true); // enables damage overlay
            Invoke(nameof(DisableOverlay), 0.5f); // disables it after 1/2 sec    }
        }

    }
    public void AddHealth(int healthAdded)
    {
        playerHealth += healthAdded;
        healthText.text = health.ToString();
    }

    void PlayerDies()
    {
        if (!playerDead)
        {
             gameOverPanel.SetActive(true); // anables game over panel
             playerMove.PlayerDies();
             sceneManager.RestartScene(2); // restarts after a 2 second delay
             playerDead = true;
        }
    }

    void DisableOverlay()
    {
        damageOverlay.SetActive(false);
    }
}
