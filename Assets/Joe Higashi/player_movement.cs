using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    Rigidbody2D rb;
    private BoxCollider2D bc;
    private Animator animator;
    float dirx=0;
    private SpriteRenderer sprite;
    float moveSpeed = 9f;
    float jumpForse = 14f;
    private enum movementState { idle,walking,jumping,punching};
    [SerializeField] private LayerMask jumpableground;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        bc=GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
         dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y);

        if(Input.GetKeyDown("space") )
        {
           rb.velocity=new Vector2(rb.velocity.x,jumpForse);

        }
        animationUpdate();
       


    }
    public void animationUpdate()
    {
        movementState state;

        if (dirx > 0f)
        {
           state=movementState.walking;
            sprite.flipX = false;
        }
        else if (dirx < 0f)
        {
            state = movementState.walking;
            sprite.flipX = true;

        }
        else
        {
            state = movementState.idle;

        }

        if (rb.velocity.y>.1f)
        {
            state = movementState.jumping;
        }
        animator.SetInteger("state", (int)state);
    }
     
}
