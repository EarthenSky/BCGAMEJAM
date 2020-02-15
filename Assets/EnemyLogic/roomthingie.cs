using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomthingie : MonoBehaviour
{
    public GameObject enemy;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
     Instantiate(enemy,new Vector3(0,0,0),Quaternion.identity);  
     Instantiate(Player,new Vector3(2.0f,2.0f,0),Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
