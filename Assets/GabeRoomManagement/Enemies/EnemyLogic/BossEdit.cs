using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEdit : MonoBehaviour
{


    public GameObject player;

    
    // creatse the shots
    void joyOfCreation(float xv, float yv) {
        GameObject s= Instantiate(Shot, transform.position, Quaternion.identity);
        s.GetComponent<Rigidbody2D>().velocity = new Vector2(xv, yv);
    }

    //this is meant to be the special enemies that the boss will summon
    //much harder to dodge and deal with 
    //more bullet hell more fun
    //these are given an initial velocity by the boss 
    public int health = 20;
    public GameObject Shot;
    private float total=0;
    public float velocity = 10.0f;
    float x1velocity, y1velocity, x2velocity, y2velocity, x3velocity, y3velocity;
    float x4velocity, y4velocity, x5velocity, y5velocity, x6velocity, y6velocity;
    float x7velocity, y7velocity, x8velocity, y8velocity;

    float angle1 = 0, angle2 = (Mathf.PI) / 4, angle3 = (Mathf.PI) / 2, angle4 = 5*(Mathf.PI) / 8;
    float angle5 = 3*(Mathf.PI) / 2, angle6 = (Mathf.PI), angle7 = 3*(Mathf.PI) / 8, angle8 = 7*(Mathf.PI) / 8;

    void FixedUpdate(){
        //get the initial angle towards the player and get 45degrees up and down to that initial angle
        //then find the x and y components of the velocity with the angle

        //velocity calculations
        x1velocity = Mathf.Cos(angle1) * velocity;
        y1velocity = Mathf.Sin(angle1) * velocity;
        x2velocity = Mathf.Cos(angle2) * velocity;
        y2velocity = Mathf.Sin(angle2) * velocity;
        x3velocity = Mathf.Cos(angle3) * velocity;
        y3velocity = Mathf.Sin(angle3) * velocity;
        x4velocity = Mathf.Cos(angle4) * velocity;
        y4velocity = Mathf.Sin(angle4) * velocity;
        x5velocity = Mathf.Cos(angle5) * velocity;
        y5velocity = Mathf.Sin(angle5) * velocity;
        x6velocity = Mathf.Cos(angle6) * velocity;
        y6velocity = Mathf.Sin(angle6) * velocity;
        x7velocity = Mathf.Cos(angle7) * velocity;
        y7velocity = Mathf.Sin(angle7) * velocity;
        x8velocity = Mathf.Cos(angle8) * velocity;
        y8velocity = Mathf.Sin(angle8) * velocity;

    }

    // deals damage to this enemy
    public void DealDamage() {
        health--;

        if(health == 0) {
            Destroy(gameObject);
        } else {
            // set color if needed
            this.GetComponent<SpriteRenderer>().color = new Color(1, health / 20f, health / 20f);
        }
    }

    void Update(){
        if (total > 1.3f) {
            //fire the 3 bullets every 1.3 seconds
            total=0;
            joyOfCreation(x1velocity, y1velocity);
            joyOfCreation(x2velocity, y2velocity);
            joyOfCreation(x3velocity, y3velocity);
            joyOfCreation(x4velocity, y4velocity);
            joyOfCreation(x5velocity, y5velocity);
            joyOfCreation(x6velocity, y6velocity);
            joyOfCreation(x7velocity, y7velocity);
            joyOfCreation(x8velocity, y8velocity);
        }
        else{
            total+=Time.deltaTime;
        }

    }
}
