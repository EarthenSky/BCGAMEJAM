using System.Collections;
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

    public void CreatePlayer() {
        playerObject = Instantiate(playerPrefab, transform.Find("Spawn").position, Quaternion.identity);
        playerScript = playerObject.GetComponent<ControlsEdit>();
    }

    public void CreateEnemies() {
        // instantiate an enemy in each position.
        foreach(Transform transform in enemyPositions) {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity, gameObject.transform);
        }
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
