using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollision : MonoBehaviour
{

    private Collider2D myCol;
    // Start is called before the first frame update
    void Start()
    {
        myCol = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collisionInfo) {
        if(collisionInfo.collider.name == "Tilemap") {
            Physics2D.IgnoreCollision(myCol, collisionInfo.collider);
        }
    }
}
