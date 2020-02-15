using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the main player class.
public class ControlsEdit : MonoBehaviour
{
    public bool completedLevel = false;
    public float moveSpeed;
    public int grounded;
    public Vector2 jumpForce;

    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        jumpForce = new Vector2(0, 1800f);   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 forewardSpeed = new Vector2(7.0f, rb.velocity.y);
        Vector2 backwardSpeed = new Vector2(-7.0f, rb.velocity.y);
        
        if(Input.GetKey("d")) {
            rb.velocity = forewardSpeed;
        } else if(Input.GetKey("a")) {
            rb.velocity = backwardSpeed;
        }

        if(Input.GetButton("Cancel") && grounded == 1) {
        //if(Input.GetKeyDown("w") && grounded == 1) {
            rb.AddForce(jumpForce);
            grounded = 0;
        }
    }

    // To
    void OnTriggerEnter2D(Collider2D col) {
        if (col.name == "ExitDoor") {
            completedLevel = true;
            Debug.Log("YAYAY");
        }
    }
}
