using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLogic : MonoBehaviour
{       
            
            int betrayal=0;
            int counter=0;
            const int POWER=1;
            float count=0;
        //tweak power later 
    //log the thing it collides with in console
    void OnCollisionEnter2D(Collision2D collisionInfo){
        if( collisionInfo.collider.name == "Tilemap" ){
            counter+=1;
        }
        else if (collisionInfo.collider.name == "Sheild(Clone)" && betrayal==0){
            counter=0;
            betrayal=1;

        }
        else if (collisionInfo.collider.name == "Sheild(Clone)" && betrayal==1){
            counter+=1;
        }
        else if (collisionInfo.collider.name == "Player" && betrayal==0){
            //take off hp later on in dev prolly saturday
            GameObject.Destroy(gameObject);
        }
        else if ((collisionInfo.collider.name == "Enemy(Clone)") && (betrayal== 1)){
            GameObject.Destroy(gameObject);
            collisionInfo.collider.gameObject.GetComponent<enemy>().Ouch();
            if (collisionInfo.collider.gameObject.GetComponent<enemy>().health < 0){
                GameObject.Destroy(collisionInfo.collider.gameObject);
            }
            
            
            
        }
    }
    void Update(){
        if (counter>=10){
            GameObject.Destroy(gameObject);
        }
        if (count<10){
            count+=Time.deltaTime;
        }
        else if (count>10.0f){
            GameObject.Destroy(gameObject);
        }
    }
}
