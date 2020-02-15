using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Braden Takashima

public class SceneTransition : MonoBehaviour
{
    //When player enters the scripted collisionbox they are transitioned to the next screen
    //Change name "moveTo" to the name if the eventual gameplay scene

    // We may want to change "moveTo" to a variable if we want to resuse this script for restarting the game or other scene tansitions
    string destination = "moveTo";
    
    
    void OnTriggerEnter2D(Collider2D Other) 
    {
        SceneManager.LoadScene(destination);
    }
}
