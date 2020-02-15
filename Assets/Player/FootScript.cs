using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this program checks if the player is touching the ground
public class FootScript : MonoBehaviour
{

//jump collision detection
    void OnCollisionEnter2D(Collision2D coll)
        {
            this.transform.parent.GetComponent<Controls>().grounded = 1;
        }
}
