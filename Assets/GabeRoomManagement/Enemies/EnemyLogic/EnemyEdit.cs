using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEdit : MonoBehaviour
{   
    // can set global.turret=false then change back to true afterwards to make it a non turret
    public bool turret = true;

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

    void Start() {
        shootWait = Random.Range(SHOOT_WAIT_MIN, SHOOT_WAIT_MAX);
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
        //Debug.Log("deg: " + angle * Mathf.Rad2Deg); 
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
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }

    }

}
