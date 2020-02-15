using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{   //can set global.turret=false then change back to true afterwards to make it a non turret
    public bool turret = true;

    public GameObject Player;
    public int health = 3;
    private float total=0;
    //change this name later to shot when the object is renamed to shot
    public GameObject Shot;
    public float velocity = 15.0f;
    Vector2 direction;
    float angle, xvelocity, yvelocity;
    public void Ouch(){
        health--;
    }
    public void Follow(){
        turret=false;
    }
   /* void Start() {
        if (turret){
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else if (!turret){
            this.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        }
        //complicated vector math to figure out the angle of the player and fire
        direction= Player.transform.position - transform.position;
        angle= Mathf.Atan2(direction.y, direction.x);// * Mathf.Rad2Deg;
        xvelocity=Mathf.Cos(angle)*velocity;
        yvelocity=Mathf.Sin(angle)*velocity;
    }*/

    // Update is called once per frame
    void FixedUpdate(){
        //complicated vector math to figure out the angle of the player and fire
        direction= Player.transform.position - transform.position;
        angle= Mathf.Atan2(direction.y, direction.x); //* Mathf.Rad2Deg;
        xvelocity=Mathf.Cos(angle)*velocity;
        yvelocity=Mathf.Sin(angle)*velocity;
        
    }
    void Update()
    {   
        float queing= Time.deltaTime;
        if (total>3.0f){
            total=0;
            GameObject s= Instantiate(Shot, transform.position, Quaternion.identity);
            s.GetComponent<Rigidbody2D>().velocity=new Vector2(xvelocity,yvelocity);
        }
        else{
            total+=queing;
        }
        if (!turret){
            this.GetComponent<Rigidbody2D>().velocity= new Vector2(Mathf.Cos(angle),Mathf.Sin(angle));
        }

    }

}
