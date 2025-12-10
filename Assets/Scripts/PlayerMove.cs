using UnityEngine;
using System.Collections;
using System;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 input = Vector2.zero;

    //Jump feature variables
    [SerializeField] private float jumpForce; //Velocity the player jumps at
    [SerializeField] private float jumpHeight = 0.6f; //Amount of time before the player stops moving up
    private float decayDelay = 0f;
    [SerializeField, Range(0, 1)] private float decayRate;
    [SerializeField] private float groundCheckRadius = 0.2f;
    public Transform groundCheck;
    public Transform headCheck;

    public LayerMask groundLayer;
    private bool isGrounded;
    private bool hitHead;
    //Used for double jump
    private bool canJump;
    private int numJumps = 0;
    
    // for animations
    private Animator animator;

    //Sound stuff
    public SoundManager sm;


    //coin count
    public int coins;

    private void Start()
    {
        animator = GetComponent<Animator>();
        sm = FindFirstObjectByType<SoundManager>();
    }


    // Update is called once per frame
    void Update()
    {

        //Getting horizontal input for movement
        input = new Vector2(Input.GetAxis("Horizontal"), input.y); //Setting y to input.y since itll modify on another line for jump input
        
        //Jump Code -----------------------------------
        //Checks for grounding every frame
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //Checks for a headbump underneath a platform
        hitHead = Physics2D.OverlapCircle(headCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded || numJumps % 2 != 0)
        {
            canJump = true;
        } else
        {
            canJump = false;
        }

        //Handles jump input
        if (canJump && Input.GetButtonDown("Jump"))
        {
            sm.PlaySound("Jump");
            input = new Vector2(input.x, 1);
            decayDelay = 0f; //Resets the delay timer for the jump smoothing
            numJumps += 1;
        }

        decayDelay += Time.deltaTime; //Decay delay timer

        if(hitHead) //If hit head start descent instantly
        {
            decayDelay = jumpHeight;
        }

        SetAnimation();
        SetRotation();
    }

    private void FixedUpdate()
    {
        if (decayDelay >= jumpHeight)
        { 
            rb.linearVelocity = new Vector2(input.x * moveSpeed, rb.linearVelocity.y - decayRate); //Smoothes the jump at its peak leading to the descent
        }else
        {
            rb.linearVelocity = new Vector2(input.x * moveSpeed, input.y * jumpForce); //Seperates the movement code into horizontal and vertical components
        }

    }

    private void SetAnimation()
    {
        if (isGrounded) // is on ground
        {
            if (rb.linearVelocityX == 0) // is moving
            {
                animator.Play("Player_idle"); // play idle if yes
            }
            else
            {
                animator.Play("Player_run"); // run if no
            }
        }
        else // not grounded
        {
            if(rb.linearVelocityY > 0) // going up
            {
                animator.Play("Player_Jump"); // jump animation if yes
            }
            else
            {
                animator.Play("Player_fall"); // falling if no
            }
        }
        
    }

    private void SetRotation()
    {
        if (rb.linearVelocityX > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }else if (rb.linearVelocityX < 0) {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BouncePad"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * 3F);

            sm.PlaySound("Boing");
        }
        else if (collision.CompareTag("Banana"))
        {
            moveSpeed += 1.75f;
            Destroy(collision.gameObject);
        }
    }
}
