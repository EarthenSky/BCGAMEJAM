using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this program will determine the position and angle of the players shield based on the relative distance of the
//player gameobject and the mouse position
public class ShieldBehaviorOliver : MonoBehaviour
{

    public GameObject player;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //calculates the angle between player and the mouse and changes the shield position based on it
        float angle;
        Vector3 pz = player.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        angle = Mathf.Rad2Deg * Mathf.Atan2(pz.y,pz.x) + 180;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
