using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    #region Parameters
    float horizontalMove = 0f;
    public float walkSpeed = 40f;
    bool jump = false;
    private Animator animator;

    [SerializeField] private float m_JumpForce = 250;                          // Amount of force added when the player jumps.
    [Tooltip("How much to smooth out the movement")]
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.                                                                               

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;
    bool DeathTrigger;
    AudioManager audioManager;
    AudioSource[] audioSources;

    public string NameOfWalkSound;
    public string NameOfJumpSound;

    #endregion

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
        Invoke(nameof(FindAudioClips), 0.2f);
    }
    void Update()
    {
        if (!DeathTrigger) // locks any further naimations when Death trigger is triggered
        {
            var walking = false;

            horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;

            if (Mathf.Abs(horizontalMove) > 0)
            {
                walking = true;

            }
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }

            animator.SetBool("isWalking", walking);

            PlayWalkingSound();
        }
    }
    private void FixedUpdate()
    {
        Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;

        bool wasGrounded = m_Grounded;
        m_Grounded = false;
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
            }
        }

    }
    public void Move(float move, bool jump)
    {

        Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);

        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

        // If the player should jump...
        if (m_Grounded && jump)
        {
            // Add a vertical force to the player.
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce), ForceMode2D.Impulse);

            audioManager.PlaySound(NameOfJumpSound, true);

            m_Grounded = false;
        }
        if (m_AirControl)
        {
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce), ForceMode2D.Impulse);
            audioManager.PlaySound(NameOfJumpSound, true);
        }


    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void FindAudioClips()
    {
        audioSources = audioManager.gameObject.GetComponentsInChildren<AudioSource>();
    }
    void PlayWalkingSound()
    {
        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            foreach (AudioSource source in audioSources)
            {
                if (!source.isPlaying && source.transform.name.Contains(NameOfWalkSound) && !jump)
                {
                    audioManager.PlaySound(NameOfWalkSound, true);
                }
            }
        }
    }


    public void PlayerHurt()
    {
        audioManager.PlaySound("AlientHurt", true);
    }
    public void PlayerWins()
    {
        audioManager.PlaySound("Victory", true);
    }
    public void PlayerDies()
    {
        DeathTrigger = true;
        animator.SetBool("isDead", true);
        audioManager.PlaySound("LevelMusic", false);
        audioManager.PlaySound("AlientDead", true);
        audioManager.PlaySound("GameOver", true);
    }
}