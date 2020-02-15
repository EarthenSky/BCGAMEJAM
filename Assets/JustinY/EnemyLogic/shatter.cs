using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shatter : MonoBehaviour
{   
    // Start is called before the first frame update
     void OnCollisionEnter2D(Collision2D collisionInfo){
         if(collisionInfo.collider.name=="Sheild"){
             collisionInfo.collider.gameObject.SetActive(false);
             //collisionInfo.collider.gameObject.GetComponent<PlayerHealth>().health = collisionInfo.collider.gameObject.GetComponent<PlayerHealth>().health/2;
             GameObject.Destroy(gameObject);
         }
         else if (collisionInfo.collider.name!="Sheild"){
             GameObject.Destroy(gameObject);
         }

        
    }


}
