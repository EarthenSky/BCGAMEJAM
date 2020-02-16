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
    public GameObject shield;
    public GameObject shieldRotate;
    public GameObject crosshairRotate;

    public float timeCounter = 2f;

    //Animation related initializers
    public SpriteRenderer m_SpriteRenderer;
    public Animator animator;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        jumpForce = new Vector2(0, 1800f);

        shield.SetActive(false);
        timeCounter = SHIELD_COOLDOWN;

        //Animation Related start items
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 forewardSpeed = new Vector2(7.0f, rb.velocity.y);
        Vector2 backwardSpeed = new Vector2(-7.0f, rb.velocity.y);
        
        if(Input.GetAxisRaw("Horizontal") > 0.1 || Input.GetKey("d")) {
            rb.velocity = forewardSpeed;
        } else if(Input.GetAxis("Horizontal") < -0.1|| Input.GetKey("a")) {
            rb.velocity = backwardSpeed;
        }

        if((Input.GetButton("xButton") || Input.GetKeyDown("w")) && grounded == 1) {
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

    const float SHIELD_COOLDOWN = 1.5f;
    const float SHEILD_DECAY_TIME = 1f;

    void Update()
    {
        //detects mouse hold and turns on shield
        if((Input.GetMouseButton(0) || Input.GetButton("squareButton")) && timeCounter >= SHIELD_COOLDOWN) {
            timeCounter = 0;
            shieldRotate.transform.rotation = crosshairRotate.transform.rotation;
            shield.SetActive(true);
        }
        timeCounter += Time.deltaTime;
        if(timeCounter >= SHEILD_DECAY_TIME) {
            shield.SetActive(false);
        }
    }

    // To
    void OnTriggerEnter2D(Collider2D col) {
        if (col.name == "ExitDoor") {
            completedLevel = true;
        }
    }
}
