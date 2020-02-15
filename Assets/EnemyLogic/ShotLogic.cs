using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLogic : MonoBehaviour
{   
    public prejudice=0;
    int counter=0;
    //log the thing it collides with in console
    void OnCollisionEnter2D(Collision2D collisionInfo){
        if( collisionInfo.collider.name == "Tilemap" ){
            counter+=1;
        }
        else if (collisionInfo.collider.name == "Sheild" && prejudice==0){
            counter=0;
            prejudice=1;

        }
        else if (collisionInfo.collider.name == "Sheild" && prejudice==1){
            counter+=1;
        }
        else if (collisionInfo.collider.name == "Player" && prejudice==0){
            //take off hp later on in dev prolly saturday
            GameObject.Destroy(gameObject);
        }
        else if (collisionInfo.collider.name == "Enemy" && prejudice==1){
            GameObject.Destroy(Enemy);
            GameObject.Destroy(gameObject);
        }
    }
    void Update(){
        if (counter>=10){
            GameObject.Destroy(gameObject);
        }
    }
}
