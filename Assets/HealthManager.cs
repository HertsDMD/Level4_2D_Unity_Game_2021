using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    int health;
    public Text healthText;
    private void Start()
    {
        health = 100;
        healthText.text = health.ToString();
    }
    void Update()
    {
        
    }
    public void Damage(int damageValue)
    {
        health -= damageValue;
        healthText.text = health.ToString();
    }

}
