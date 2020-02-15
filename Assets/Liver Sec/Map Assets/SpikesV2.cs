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
            Debug.Log("spikes");
            PlayerHealth player = (PlayerHealth)FindObjectOfType(typeof(PlayerHealth));
            if (player)
            {
                player.health = 0;
            }
            Debug.Log((player.health));
            //kill player here
        }
        

    }
}
