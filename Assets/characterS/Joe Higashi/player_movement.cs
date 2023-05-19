using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    internal Rigidbody2D rb;
    internal BoxCollider2D bc;
    internal Animator animator;
    internal float dirx =0;
    internal SpriteRenderer sprite;
    internal float moveSpeed = 9f;
    internal float jumpForse = 14f;
    internal enum movementState {idle,walking,jumping,punching,kicking};
    [SerializeField] internal LayerMask jumpableground;
    internal movementState state;

    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        bc=GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
         dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y);

        if(Input.GetKeyDown("space"))
        {
           rb.velocity=new Vector2(rb.velocity.x,jumpForse);

        }
        animator.SetInteger("state", (int)state);
        
        
        //animationUpdate();
        if (Input.GetKeyDown("1"))
        {
            animator.SetInteger("state", 3);
        }
        if (Input.GetKeyDown("2"))
        {
            animator.SetInteger("state", 4);
        }
        if (Input.GetKeyDown("3"))
        {
            animator.SetInteger("state", 3);
        }
        if (Input.GetKeyDown("4"))
        {
            animator.SetInteger("state", 6);
        }



    }
    public void animationUpdate()
    {


        if (Input.GetKeyDown("1"))
        {
            state = movementState.punching;
        }
        if (dirx > 0f)
        {
           state=movementState.walking;
            
        }
        else if (dirx < 0f)
        {
            state = movementState.walking;
            

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
    public void walk()
    {

    }
}
