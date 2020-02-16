using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapCollision : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("Shield").GetComponent<Collider2D>());
    }

}
