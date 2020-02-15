using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootScriptEdit : MonoBehaviour
{
    //jump collision detection
    void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.name == "Tilemap") {
            this.transform.parent.GetComponent<ControlsEdit>().grounded = 1;
        //}
        // else do nothing ^w^
    }
}
