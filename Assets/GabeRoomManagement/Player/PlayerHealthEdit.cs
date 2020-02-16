using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthEdit : MonoBehaviour
{
    public int health;
    public bool dead;
    public GameObject textBar;
    public GameObject hpBar;
    private TextMesh hpText;
    void Start()
    {
        // Find the things in the scene.
        textBar = GameObject.Find("HealthText");
        hpBar = GameObject.Find("Bar"); 

        //sets up the textmesh and the starting values of the health and dead variables
        hpText = textBar.GetComponent<TextMesh>();
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {   
        //prints hp to text
        float hpPercent = health/100f;
        hpText.text = health.ToString() + " / 100";
        hpBar.transform.localScale = new Vector3(hpPercent,0.2f,1);
        //checks if player is dead
        if(health <= 0) {
            dead = true;
            SceneManager.LoadScene("TODO: put a scene here");
        }
    }
}
