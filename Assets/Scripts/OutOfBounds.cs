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

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        if (fallCheck !=null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(fallCheck.position, Vector2.right * 100);
            Gizmos.DrawRay(fallCheck.position, Vector2.left * 100);
        }
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
