using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce = 20f;
    public float jumpForce = 700f;
    public float maxVelocity = 4f;
   

    private bool m_grounded;

    private Rigidbody2D myBody;
    private Animator anim;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerWalkKeyBoard();
    }

    void PlayerWalkKeyBoard()
    {
        float forceX = 0f;
        float forceY = 0f;

        float vel = Mathf.Abs(myBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal"); // -1 0 1

        if (h>0)
        {
            if (vel < maxVelocity)
            {
                if (m_grounded)
                {
                    forceX = moveForce;
                }
                else forceX = moveForce * 1.1f;

            }
            Vector3 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;
            anim.SetBool("Walk", true);
        } else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                if (m_grounded)
                {
                    forceX = -moveForce;
                }
                else forceX =-moveForce * 1.1f;

            }
            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;
            anim.SetBool("Walk", true);
        }  else if (h == 0)
        {
            anim.SetBool("Walk", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (m_grounded)
            {
                m_grounded = false;
                forceY = jumpForce;
            }
        }

        myBody.AddForce(new Vector2(forceX, forceY));
    }


    public void BouncePlayerWithBouncy(float force)
    {
        if (m_grounded)
        {
            m_grounded = false;
            myBody.AddForce(new Vector2(0, force));
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            m_grounded = true;
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bouncy")
        {
            myBody.AddForce(new Vector2(0, BouncyForce));
            anim.SetBool("Walk", false);
        }
    }*/
}
