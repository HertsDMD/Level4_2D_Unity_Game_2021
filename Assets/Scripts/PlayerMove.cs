using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 400f;
    public float jumpSpeed = 200f;
    bool isJumping;
    Rigidbody2D RB;
    Animator animator;
    float playerScale;
    public LayerMask groundLayer;
    public Transform groundCheck;

    AudioManager audioManager;

    bool DeathTrigger;
    enum Direction { idle, left, right };
    Direction playerState = Direction.idle;

    void Start()
    {
        RB = GetComponentInChildren<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        playerScale = transform.localScale.x;
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (!DeathTrigger) // locks any further naimations when Death trigger is triggered
        {

            if (Input.GetKey("d"))
            {
                playerState = Direction.right;
                animator.SetBool("isWalking", true);

            }
            if (Input.GetKey("a"))
            {
                playerState = Direction.left;
                animator.SetBool("isWalking", true);
            }

            else if (RB.velocity.magnitude <= 0.5f)
            {
                animator.SetBool("isWalking", false);
            }
            PlayWalkingSound();
            Jump();
        }
    }
    void Jump()
    {
        Collider2D groundCollider = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if (groundCollider != null)
        {
            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                audioManager.PlaySound("AlienJumping", true);
            }
        }
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            RB.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            isJumping = false;
        }
        switch (playerState)
        {
            case Direction.right:
                RB.AddForce(Vector2.right * moveSpeed);
                transform.localScale = new Vector3(playerScale, transform.localScale.y, 0);
                playerState = Direction.idle;
                break;
            case Direction.left:
                RB.AddForce(Vector2.left * moveSpeed);
                transform.localScale = new Vector3(-playerScale, transform.localScale.y, 0);
                playerState = Direction.idle;
                break;
        }
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
    public void PlayerWins()
    {

    }
    public void PlayerDies()
    {
        DeathTrigger = true;
        animator.SetBool("isDead", true);
    }
}