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

    //Animation related initializers
    public SpriteRenderer m_SpriteRenderer;
    public Animator animator;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        shield.SetActive(false);

        //Animation Related start items
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
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
        //Sets animation parameters
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("verticalSpeed", rb.velocity.y);

        if ((rb.velocity.x) > 0)
        {
            m_SpriteRenderer.flipX = false;
        }

        else if (rb.velocity.x < 0)
        {
            m_SpriteRenderer.flipX = true;
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
