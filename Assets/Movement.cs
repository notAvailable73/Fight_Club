using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static player_movement;

public class Movement : MonoBehaviour
{
     
   Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    bool isGrounded;
    [SerializeField]
    float runSpeed = 1.5f;
    [SerializeField]
    float jumpSpeed = 5f;
    [SerializeField]
    Transform groundCheck;
    private bool isRight;

    void Start()
    {
         animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        flip();
         if(Input.GetButtonDown("Fire1")) 
        {

            animator.Play("Punch");
        
        }
         if(Input.GetButtonDown("Fire2"))
        {
            animator.Play("Kick");
        }

if(Input.GetButtonDown("Fire3"))
        {
            animator.Play("Swift_Kick");
        }
 
        
    }
    private void FixedUpdate()
    {

        if(Physics2D.Linecast(transform.position,groundCheck.position,1<<LayerMask.NameToLayer("Ground")))
            {
            isGrounded = true;
        }

        
        else 
            isGrounded= false;



            if(Input.GetKey("d"))
        {
            rb2d.velocity = new Vector2 (runSpeed , rb2d.velocity.y);
            animator.Play("Run");
            
        }
        else if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            animator.Play("Run");
            
        }
         
        if (Input.GetKey("space"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            animator.Play("Jump");
        }
    }
    private void flip()
    {
        if (isRight && Input.GetKey("a") || !isRight && Input.GetKey("d"))
        {
            isRight = !isRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
