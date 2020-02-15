using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controls : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject shieldRotate;
    public GameObject shield;
    public GameObject crosshairRotate;
    public float moveSpeed;

    public int grounded;
    public float counter;

   


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        shield.SetActive(false);
        
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
        
    }

    void Update()
    {
        //detects mouse hold and turns on shield
        if(Input.GetMouseButton(0) && counter >= 2f)
        {
            counter = 0;
            shieldRotate.transform.rotation = crosshairRotate.transform.rotation;
            shield.SetActive(true);
        }
        counter += Time.deltaTime;
        if(counter >= 1.5f)
        {
            shield.SetActive(false);
        }
    }
}
