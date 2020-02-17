using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLogicEdit : MonoBehaviour
{          
    private Collider2D myCol;
    const int DAMAGE = 10;
    const float MAXSPEED = 5;
    public Rigidbody2D rb;
    int betrayal = 0;
    int counter = 0;
    float count = 0;

    void Start() {
        myCol = this.GetComponent<Collider2D>();
    }
    
    // tweak power later 
    // log the thing it collides with in console
    void OnCollisionEnter2D(Collision2D collisionInfo) {
        if(collisionInfo.collider.name == "Tilemap" || collisionInfo.gameObject.name == "Damage Blocks") {
            counter += 1;
        } else if (collisionInfo.collider.name == "Shield" && betrayal == 0) {
            counter = 0;
            betrayal = 1;
            
            //Physics2D.IgnoreCollision(collisionInfo.collider, myCol, false);
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
        } else if((collisionInfo.collider.name == "Enemy(Clone)") && (betrayal == 0)) {
            //Physics2D.IgnoreCollision(collisionInfo.collider, myCol, true);
        }
    }

    const int MAX_BOUNCE = 15;
    const float ALIVE_TIME = 6f;
    

    void Update() {
        Vector2 v2 = rb.velocity;

        // max bounces
        if (counter >= MAX_BOUNCE){
            GameObject.Destroy(gameObject);
        } 
        //max speed
        if (v2.x >= MAXSPEED){
            v2.x = MAXSPEED;
        }
        else if (v2.y >= MAXSPEED){
            v2.y = MAXSPEED;
        }
        else if (v2.y <= -MAXSPEED){
            v2.y = -MAXSPEED;
        }
        else if (v2.x <= -MAXSPEED){
            v2.x = -MAXSPEED;
        }
        rb.velocity = v2;
        // max bounce
        if (count < ALIVE_TIME){
            count += Time.deltaTime;
        } else if (count > ALIVE_TIME){
            GameObject.Destroy(gameObject);
        }
    }
}
