using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialEnemy : MonoBehaviour
{
    float trig(GameObject chase, specialEnemy chaser){
        Vector2 direction;
        direction = chase.transform.position - chaser.transform.position;
        return Mathf.Atan2(direction.y, direction.x);
    }
    void joyOfCreation(float xv, float yv){
        GameObject s= Instantiate(Shot, transform.position, Quaternion.identity);
        s.GetComponent<Rigidbody2D>().velocity=new Vector2(xv,yv);
    }
    //this is meant to be the special enemies that the boss will summon
    //much harder to dodge and deal with 
    //more bullet hell more fun
    //these are given an initial velocity by the boss 
    public GameObject Shot;
    public GameObject Player;
    private float total=0;
    public float velocity = 25.0f;
    float angle, angleUp, angleDown, x1velocity, y1velocity, x2velocity, y2velocity, x3velocity, y3velocity;

    void FixedUpdate(){
        //get the initial angle towards the player and get 45degrees up and down to that initial angle
        //then find the x and y components of the velocity with the angle
        angle=trig(Player,this);
        angleUp = angle + (Mathf.PI) / 4;
        angleDown = angle - (Mathf.PI) / 4;
        //velocity calculations
        x1velocity = Mathf.Cos(angle) * velocity;
        y1velocity = Mathf.Sin(angle) * velocity;
        x2velocity = Mathf.Cos(angleUp) * velocity;
        y2velocity = Mathf.Sin(angleUp) * velocity;
        x3velocity = Mathf.Cos(angleDown) * velocity;
        y3velocity = Mathf.Sin(angleDown) * velocity;

    }
    void Update(){
        if (total>1.3f){
            //fire the 3 bullets every 1.3 seconds
            total=0;
            joyOfCreation(x1velocity,y1velocity);
            joyOfCreation(x2velocity,y2velocity);
            joyOfCreation(x3velocity,y3velocity);
           
        }
        else{
            total+=Time.deltaTime;
        }

    }
}
