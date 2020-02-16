using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collisionInfo) {
        if(collisionInfo.collider.name == "Tilemap") {
            Physics2D.IgnoreCollision(collisionInfo.collider, this.GetComponent<Collider2D>());
        }
    }
}
