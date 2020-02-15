using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesV2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "Player")
        {
            Debug.Log("You hit the spikes and should die.");
            //kill player in playerHealth with a similar collision method
        }
        

    }
}
