using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpSpeed = 20;
    Rigidbody2D RB;
    Animator animatior;
    float playerScale;
    public LayerMask groundLayer;
    public Transform groundCheck;
   
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        animatior = GetComponent<Animator>();
        playerScale = transform.localScale.x;
    }      

    void Update()
    {
        if (Input.GetKey("d"))
        {
            RB.AddForce(Vector2.right * moveSpeed);
            animatior.SetBool("isWalking", true);
            transform.localScale = new Vector3(playerScale, transform.localScale.y, 0);
           
        }
         if (Input.GetKey("a"))
        {
            RB.AddForce(Vector2.left * moveSpeed);
            animatior.SetBool("isWalking", true);
            transform.localScale = new Vector3(-playerScale, transform.localScale.y, 0);
        }         

        else if (RB.velocity.magnitude <= 0.5f)
        {
            animatior.SetBool("isWalking", false);
        }

        Jump();
    }
    void Jump()
    {
        Collider2D groundCollider = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
      
        if (groundCollider != null)
        {
            if (Input.GetButtonDown ("Jump"))
            {
                RB.AddForce(Vector2.up * jumpSpeed,ForceMode2D.Impulse);
            }
        }           
    }
}
