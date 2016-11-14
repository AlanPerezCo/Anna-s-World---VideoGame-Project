using UnityEngine;
using System.Collections;

public class annaInput : MonoBehaviour
{
    //floats
    public float MaxSpeed = 3;
    public float speed = 20f;
    public float JumpPower = 200f;

    //booleans
    public bool grounded;
    public bool canDoubleJump;

    //referencias
    private Rigidbody2D rb2d;
    private Animator anim;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

    }

    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb2d.AddForce(Vector2.up * JumpPower);
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * JumpPower);
                }
            }
        }
    }
    
    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.95f; //multiplica la easeVelocity para reducir la velocidad en x

        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce((Vector2.right * speed) * h); //esta linea mueve al personaje
        
        //hacer friccion
        if (grounded)
        {
            rb2d.velocity = easeVelocity;
        }

        //estos if son limitantes de velocidad
        if(rb2d.velocity.x > MaxSpeed)
        {
            rb2d.velocity = new Vector2(MaxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -MaxSpeed)
        {
            rb2d.velocity = new Vector2(-MaxSpeed, rb2d.velocity.y);
        }
    }
}