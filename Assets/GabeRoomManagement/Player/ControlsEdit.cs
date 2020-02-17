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
        // Do jumping first
        if((Input.GetButton("xButton") || Input.GetKeyDown("w")) && grounded == 1) {
            rb.AddForce(jumpForce);
            grounded = 0;
        }

        Vector2 forewardSpeed = new Vector2(7.0f, rb.velocity.y);
        Vector2 backwardSpeed = new Vector2(-7.0f, rb.velocity.y);
        Vector2 tmpVelocity = new Vector2(0, 0);

        if(Input.GetAxisRaw("Horizontal") > 0.1 || Input.GetKey("d")) {
            tmpVelocity = forewardSpeed;
            m_SpriteRenderer.flipX = false;
        } else if(Input.GetAxis("Horizontal") < -0.1|| Input.GetKey("a")) {
            tmpVelocity = backwardSpeed;
            m_SpriteRenderer.flipX = true;
        }

        // Calculate the approximate distance that will be traversed
        float distance = tmpVelocity.magnitude * Time.fixedDeltaTime;

        // Check if the body's current velocity will result in a collision & stop movement
        RaycastHit2D hit = Physics2D.Raycast(rb.position, tmpVelocity.normalized);
        if(hit.collider != null && (hit.distance < distance)) {
            rb.velocity = tmpVelocity;
        }  
        
        //Sets animation parameters
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("verticalSpeed", rb.velocity.y);
    }

    const float SHIELD_COOLDOWN = 0.01f;
    const float SHEILD_DECAY_TIME = 0.01f;

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
