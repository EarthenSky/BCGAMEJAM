using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEdit : MonoBehaviour
{   
    // can set global.turret=false then change back to true afterwards to make it a non turret
    public bool turret = true;
	
    public int moveState;
    public int moveTempState = 0;
	const int STATE_STATIC = 0;
	const int STATE_HORIZONTAL_MOVE = 1;
	const int STATE_VERTICAL_MOVE = 2;
	const int STATE_RAND_MOVE = 3;
	const int STATE_FOLLOW_MOVE = 4;
    
    public float speed = 5f;

	public GameObject player;
    public int health = 3;
    private float total = 0;
    
    //change this name later to shot when the object is renamed to shot
    public GameObject shot;
    public float velocity = 9.0f;
    float angle, xvelocity, yvelocity;

    const float SHOOT_WAIT_MAX = 2.5f;
    const float SHOOT_WAIT_MIN = 1f;

    float shootWait;

    private Rigidbody2D rb;

    void Start() {
        shootWait = Random.Range(SHOOT_WAIT_MIN, SHOOT_WAIT_MAX);
        rb = this.GetComponent<Rigidbody2D>();

        if(transform.parent.gameObject.name == "STATE_STATIC")
            moveState = STATE_STATIC;
        else if(transform.parent.gameObject.name == "STATE_STATIC")
            moveState = Random.Range(0, STATE_FOLLOW_MOVE + 1);
        else
            moveState = STATE_STATIC;  // default

    }

    // deals damage to this enemy
    public void DealDamage() {
        health--;

        if(health == 0) {
            Destroy(gameObject);
        } else {
            // set color if needed
            this.GetComponent<SpriteRenderer>().color = new Color(1, health / 3.0f, health / 3.0f);
        }
    }
    
    public void Follow() {
        turret = false;
    }

    // Update is called once per frame
    void FixedUpdate() {
        //complicated vector math to figure out the angle of the player and fire
        Vector2 direction = player.transform.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x); //* Mathf.Rad2Deg;
        xvelocity = Mathf.Cos(angle) * velocity;
        yvelocity = Mathf.Sin(angle) * velocity;
    }

    void Update()
    {   
        float queing = Time.deltaTime;
        if (total > shootWait){
            total = 0;
            GameObject s = Instantiate(shot, transform.position + new Vector3(xvelocity / 15, yvelocity / 15, 0), Quaternion.identity);
            s.GetComponent<Rigidbody2D>().velocity = new Vector2(xvelocity, yvelocity);
        } else {
            total += queing;
        } if (!turret){
            rb.velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }

        if(moveState == STATE_STATIC) {
            // dont move
        } else if (moveState == STATE_HORIZONTAL_MOVE) {
            if(moveTempState == 0) {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            } else {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "Tilemap" || col.gameObject.name == "Damage Blocks") {
            if (moveState == STATE_HORIZONTAL_MOVE) {
                moveTempState = (moveTempState == 0) ? 1 : 0;
            }
        }
    }
}
