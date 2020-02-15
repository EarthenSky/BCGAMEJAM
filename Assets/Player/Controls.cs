using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controls : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject shield;
    public float moveSpeed;

    public int grounded;


   


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 forewardSpeed = new Vector2(7.0f,rb.velocity.y);
        Vector2 backwardSpeed = new Vector2(-7.0f,rb.velocity.y);
        Vector2 jumpForce = new Vector2(0,1000f);
        //detect key inputs and moves player
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
        //detects mouse hold and turns on shield
        if(Input.GetMouseButton(0))
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }
    }
}
