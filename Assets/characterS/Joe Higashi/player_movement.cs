using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_movement : MonoBehaviour
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
        if (Input.GetButtonDown("jFire1"))
        {

            animator.Play("p1_punch");

        }
        if (Input.GetButtonDown("jFire2"))
        {
            animator.Play("p1_kick");
        }

        if (Input.GetButtonDown("jFire3"))
        {
            animator.Play("Swift_Kick");
        }


    }
    private void FixedUpdate()
    {

        float dirx = Input.GetAxis("jHorizontal");


        if (Input.GetButtonDown("jHorizontal"))
        {
            
           
            rb2d.velocity = new Vector2(dirx*runSpeed, rb2d.velocity.y);
            animator.Play("p1_walk");

        }
        else if (Input.GetButtonDown("jHorizontal"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            animator.Play("p1_walk");

        }

        if (Input.GetButtonDown("Jump1") )
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            animator.Play("p1_Jump");
        }
    }
    private void flip()
    {
        if (isRight && Input.GetButtonDown("jHorizontal") || !isRight && Input.GetButtonDown("jHorizontal"))
        {
            isRight = !isRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
