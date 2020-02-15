using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 forewardSpeed = new Vector2(5.0f,0);
        Vector2 backwardSpeed = new Vector2(-5.0f,0);
        Vector2 jumpForce = new Vector2(0,100f);
        int jumping = 0;

        if(Input.GetKey("d"))
        {
            rb.velocity = forewardSpeed;
        }

        if(Input.GetKey("a"))
        {
            rb.velocity = backwardSpeed;
        }

        if(Input.GetKeyDown("w") && jumping != 1)
        {
            jumping = 1;
            rb.AddForce(jumpForce);
        }
        jumping = 0;
    }
}
