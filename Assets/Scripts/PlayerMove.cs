using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpSpeed = 20;
    Rigidbody2D RB;
    Animator animator;
    float playerScale;
    public LayerMask groundLayer;
    public Transform groundCheck;

    AudioManager audioManager;

    bool DeathTrigger;
   
    void Start()
    {
        RB = GetComponentInChildren<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        playerScale = transform.localScale.x;
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {

        if (!DeathTrigger) // locks any further naimations one Death trigger is... triggered
        {

            if (Input.GetKey("d"))
            {
                RB.AddForce(Vector2.right * moveSpeed);
                animator.SetBool("isWalking", true);
                transform.localScale = new Vector3(playerScale, transform.localScale.y, 0);

            }
            if (Input.GetKey("a"))
            {
                RB.AddForce(Vector2.left * moveSpeed);
                animator.SetBool("isWalking", true);
                transform.localScale = new Vector3(-playerScale, transform.localScale.y, 0);
            }

            else if (RB.velocity.magnitude <= 0.5f)
            {
                animator.SetBool("isWalking", false);
            }

            Jump();
            PlayWalkingSound();
        }
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
    public void PlayerDies()
    {
        DeathTrigger = true;
        animator.SetBool("isDead", true);
    }

    void PlayWalkingSound()
    {
        if (Input.GetKeyDown("a") || Input.GetKeyDown("d"))
        {
            audioManager.PlaySound("AlienWalking", true);
        }
        if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            audioManager.PlaySound("AlienWalking", false);
        }
    }
}
