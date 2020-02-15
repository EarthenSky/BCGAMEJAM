using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootScript : MonoBehaviour
{

//jump collision detection
    void OnCollisionEnter2D(Collision2D coll)
        {
            this.transform.parent.GetComponent<Controls>().grounded = 1;
        }
}
