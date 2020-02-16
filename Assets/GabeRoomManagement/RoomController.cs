﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// This class owns the player.
public class RoomController : MonoBehaviour
{
    //public bool makeNextPlayer = false;  // 
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public GameObject playerObject;
    public ControlsEdit playerScript;

    public List<Transform> enemyPositions;  // preset things

    // Start is called before the first frame update
    void Start()
    { 

    }

    public void CreatePlayer(int health) {
        playerObject = Instantiate(playerPrefab, transform.Find("Spawn").position, Quaternion.identity);
        playerObject.name = "Player";

        playerScript = playerObject.GetComponent<ControlsEdit>();
        playerObject.GetComponent<PlayerHealthEdit>().health = health;  // only calling once so its good.
    }

    public void CreateEnemies() {
        // instantiate an enemy in each position.
        foreach(Transform transform in enemyPositions) {
            GameObject tmpEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity, gameObject.transform);
            tmpEnemy.GetComponent<EnemyEdit>().player = playerObject; 
        }
    }

    //TODO: implement this.
    public void DestroyEnemies() {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if player beat level, destroy it.
        //if(playerScript != null && playerScript.completedLevel == true) {
        //    if(playerObject != null) GameObject.Destroy(playerObject);
        //}
    }
}
