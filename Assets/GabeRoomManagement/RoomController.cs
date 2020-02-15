using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// This class owns the player.
public class RoomController : MonoBehaviour
{
    //public bool makeNextPlayer = false;  // 
    public GameObject playerPrefab;
    public GameObject playerObject;
    public ControlsEdit playerScript;

    // Start is called before the first frame update
    void Start()
    { 
    }

    public void CreatePlayer() {
        playerObject = Instantiate(playerPrefab, transform.Find("Spawn").position, Quaternion.identity);
        playerScript = playerObject.GetComponent<ControlsEdit>();
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
