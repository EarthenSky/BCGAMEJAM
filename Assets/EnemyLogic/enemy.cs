using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{   
    public GameObject Player;
    public int health = 3;
    const int ENEMY = 0;
    const int PLAYER=1;
    public int type = ENEMY;
    private float total=0;
    //change this name later to shot when the object is renamed to shot
    public GameObject ball;
    public float velocity = 30.0f;
    Vector2 direction;
    float angle, xvelocity, yvelocity;
    void Start() {
        
        //complicated vector math to figure out the angle of the player and fire
        direction= Player.transform.position - transform.position;
        angle= Mathf.Atan2(direction.y, direction.x);// * Mathf.Rad2Deg;
        xvelocity=Mathf.Cos(angle)*velocity;
        yvelocity=Mathf.Sin(angle)*velocity;
    }

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
        if (total>0.0f){
            total=0;
            GameObject s= Instantiate(ball, transform.position, Quaternion.identity);
            s.GetComponent<Rigidbody2D>().velocity=new Vector2(xvelocity,yvelocity);
        }
        else{
            total+=queing;
        }

    }

}
