using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLogicEdit : MonoBehaviour
{          
    const int DAMAGE = 10;

    int betrayal = 0;
    int counter = 0;
    float count = 0;
    
    // tweak power later 
    // log the thing it collides with in console
    void OnCollisionEnter2D(Collision2D collisionInfo) {
        if(collisionInfo.collider.name == "Tilemap") {
            counter += 1;
        } else if (collisionInfo.collider.name == "Shield" && betrayal == 0) {
            counter = 0;
            betrayal = 1;
            this.GetComponent<SpriteRenderer>().color = Color.blue;
        } else if (collisionInfo.collider.name == "Shield" && betrayal == 1) {
            counter += 1;
        } else if (collisionInfo.collider.name == "Player" && betrayal == 0){
            GameObject.Destroy(gameObject);
            collisionInfo.collider.gameObject.GetComponent<PlayerHealthEdit>().health -= DAMAGE;  // player takes damage.
        } else if ((collisionInfo.collider.name == "Enemy(Clone)") && (betrayal == 1)) {
            GameObject.Destroy(gameObject);

            collisionInfo.collider.gameObject.GetComponent<EnemyEdit>().DealDamage();
            if (collisionInfo.collider.gameObject.GetComponent<EnemyEdit>().health < 0){
                GameObject.Destroy(collisionInfo.collider.gameObject);
            }  
        }
    }

    const int MAX_BOUNCE = 6;
    const float ALIVE_TIME = 5f;

    void Update() {
        // max bounces
        if (counter >= MAX_BOUNCE){
            GameObject.Destroy(gameObject);
        } 
        
        // max bounce
        if (count < ALIVE_TIME){
            count += Time.deltaTime;
        } else if (count > ALIVE_TIME){
            GameObject.Destroy(gameObject);
        }
    }
}
