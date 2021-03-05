using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKitCollected : MonoBehaviour
{
    HealthManager healthManager;
    public int healthAdded = 50;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            healthManager.AddHealth(healthAdded);
            anim.SetBool("Collected", true);
            Destroy(gameObject, 1);          
        }
    }
}
