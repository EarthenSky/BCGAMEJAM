using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int dead;
    public GameObject textBar;
    private TextMesh hpText;
    void Start()
    {
        hpText = textBar.GetComponent<TextMesh>();
        health = 100;
        dead = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        //prints hp to text
        hpText.text = "HP: " + health.ToString();
        if(health <= 0)
        {
            dead = 1;
        }
    }
}
