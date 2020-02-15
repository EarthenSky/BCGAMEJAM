using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //When player enters the scripted collisionbox they are transitioned to the next screen
    //Change name "moveTo" to the name if the eventual gameplay scene
    void OnTriggerEnter2D(Collider2D Other) 
    {
        SceneManager.LoadScene("moveTo");
    }
}
