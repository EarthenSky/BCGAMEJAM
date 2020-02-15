﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthEdit : MonoBehaviour
{
    public int health;
    public int dead;
    void Start()
    {
        health = 100;
        dead = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            dead = 1;
        }
    }

    void killPlayer()
    {
        health = 0;
    }
}
