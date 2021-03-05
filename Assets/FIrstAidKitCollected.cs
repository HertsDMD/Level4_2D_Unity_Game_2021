using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIrstAidKitCollected : MonoBehaviour
{
    HealthManager healthManager;
    public int healthAdded = 50;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            healthManager.AddHealth(healthAdded);
            Destroy(gameObject, 1);
        }
    }
}
