using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alif_Joystick : MonoBehaviour
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
    float dirx;

    private bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Input.GetAxis("Horizontal1") * runSpeed,0, rb2d.velocity.y);
        float dirx = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(dirx * runSpeed, rb2d.velocity.y);


        if (Input.GetButtonDown("Jump1"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            animator.Play("Jump");
        }

        flip();
        if (Input.GetButtonDown("jFire1"))
        {

            animator.Play("Punch");

        }
        if (Input.GetButtonDown("jFire2"))
        {
            animator.Play("Kick");
        }



    }
    private void FixedUpdate()
    {

    }
    void jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        animator.Play("Jump");
    }
    private void flip()
    {

    }
}
