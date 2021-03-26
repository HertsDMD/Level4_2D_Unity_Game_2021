using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKitCollected : MonoBehaviour
{
    HealthManager healthManager;
    public int healthAdded = 50;
    Animator anim;
    ParticleSystem CollectionParticles;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
        anim = GetComponent<Animator>();
        CollectionParticles = GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!healthManager.FullHealth)
        {
             if (collision.CompareTag("Player"))
             {
                 healthManager.AddHealth(healthAdded);
                 anim.SetBool("Collected", true);
                    CollectionParticles.Play();
                 Destroy(gameObject, 1f);          
              }
        }
    }
}