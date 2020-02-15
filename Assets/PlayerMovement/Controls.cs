using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controls : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;

    public int grounded;
    //public GameObject foot;
   // public FootScript fs;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //fs = foot.GetComponent<FootScript>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 forewardSpeed = new Vector2(7.0f,rb.velocity.y);
        Vector2 backwardSpeed = new Vector2(-7.0f,rb.velocity.y);
        Vector2 jumpForce = new Vector2(0,1000f);

        if(Input.GetKey("d"))
        {
            rb.velocity = forewardSpeed;
        }

        if(Input.GetKey("a"))
        {
            rb.velocity = backwardSpeed;
        }

        if(Input.GetKeyDown("w") && grounded == 1)
        {
            rb.AddForce(jumpForce);
            grounded = 0;
        }
    }
}
