using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    HealthManager healthManager;
    Transform player;
    Transform fallCheck;


    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        fallCheck = GameObject.FindGameObjectWithTag("FallCheck").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.position.y <= fallCheck.position.y)
        {
            healthManager.Damage(100);
        }
    }
}
