﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this class will store the health variable and write the HP to screen
//it will also check if the HP is 0 or below and change a boolean variable saying that the player is dead
public class PlayerHealth : MonoBehaviour
{
    public int health;
    public bool dead;
    public GameObject textBar;
    private TextMesh hpText;
    void Start()
    {
        //sets up the textmesh and the starting values of the health and dead variables
        hpText = textBar.GetComponent<TextMesh>();
        health = 100;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {   
        //prints hp to text
        hpText.text = "HP: " + health.ToString();
        //checks if player is dead
        if(health <= 0)
        {
            dead = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "Damage Blocks")
        {
            health = 0;
            Debug.Log("hit spikes");
        }
    }
}
