using UnityEngine;

public class Movement : MonoBehaviour
{

    public Animator animator;
    public Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    [SerializeField]
    float runSpeed = 1.5f;
    [SerializeField]
    float jumpSpeed = 5f;
    [SerializeField]
    Transform groundCheck;
    private bool isRight;
    public GameObject punchPoint , kickPoint,kickpoint2, kickpoint3,kickpoint4;
    public float punchRadius;
    public float kickRadius, kickradius2, kickradius3,kickradius4;
    public LayerMask opponents;

    void Start()
    {

        //opponents = GetComponent<LayerMask>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        flip();
        if (Input.GetButtonDown("Fire1"))
        {

            animator.Play("Punch");

        }
        if (Input.GetButtonDown("Fire2"))
        {
            animator.Play("Kick");
        }

        if (Input.GetButtonDown("Fire3"))
        {
            animator.Play("Swift_Kick");
        }


    }
    private void FixedUpdate()
    {

                

        if (Input.GetKey("d"))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            animator.Play("Run");

        }
        else if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            animator.Play("Run");

        }

        if (Input.GetKeyDown("space") && !(animator.GetBool("isjumping")))
        {
            jump();
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
    void endJump()
    {
        animator.SetBool("isjumping", false);

    }
    void jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        animator.Play("Jump");
        animator.SetBool("isjumping", true);
    }
    public void punch()
    {
        Collider2D[] opponent = Physics2D.OverlapCircleAll(punchPoint.transform.position, punchRadius, opponents);
        foreach (Collider2D opponentObject in opponent)
        {
            damage(10);
        }
    }
    public void kick()
    {
        Collider2D[] opponent = Physics2D.OverlapCircleAll(kickPoint.transform.position, kickRadius, opponents);
        foreach (Collider2D opponentObject in opponent)
        {
            damage(20);
        }
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(punchPoint.transform.position, punchRadius);
    //    Gizmos.DrawWireSphere(kickPoint.transform.position, kickRadius);
    //    Gizmos.DrawWireSphere(kickpoint2.transform.position, kickradius2);
    //    Gizmos.DrawWireSphere(kickpoint3.transform.position, kickradius3);
    //    Gizmos.DrawWireSphere(kickpoint4.transform.position, kickradius4);
    //}
    void damage(int d)
    {
        staticClass.player2Health -= d;
    }
}
