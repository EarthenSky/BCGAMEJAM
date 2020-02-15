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
        Vector2 forewardForce = new Vector2(1.5f,0);
        Vector2 backwardForce = new Vector2(-1.5f,0);
        Vector2 jumpForce = new Vector2(0,10f);

        if(Input.GetKey("d"))
        {
            rb.velocity = forewardForce;
        }
    }
}
