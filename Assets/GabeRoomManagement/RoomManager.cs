﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This class has authority over The rooms the player's prefab.
/// 
public class RoomManager : MonoBehaviour
{
    const float CAMERA_SPEED = 10f;

    const int ROOM_WIDTH = 42;
    const int ROOM_HEIGHT = 24;
    const int ROOM_COUNT = 10;
    public int currentRoomNum = 0;
    public List<GameObject> rooms;
    
    public GameObject currentRoom;
    public RoomController currentRoomController;
    public GameObject lastRoom;
    public RoomController lastRoomController;
    
    public Transform camTrans;
    public GameObject playerPrefab;
    private bool cameraAtNewScene = true;

    void Start()
    {
        CreateRoom();
        //cameraAtNewScene = true;
        //currentRoomController.CreatePlayer();
    }

    // todo: do random unused room.
    private GameObject GetRandomRoom() {
        int rand = Random.Range(0, rooms.Count);
        return rooms[rand];
    }

    private void CreateRoom() {
        if(currentRoomNum == ROOM_COUNT) { // Spawn boss room if in last room.
            CreateBossRoom();
        } else {  // Spawn current room
            if(lastRoom != null) GameObject.Destroy(lastRoom);  // Remove the old room.

            lastRoom = currentRoom;
            currentRoom = GetRandomRoom();  // Get new room
            currentRoom = Instantiate(currentRoom, new Vector3(ROOM_WIDTH * currentRoomNum, 0, 0), Quaternion.identity);
            
            lastRoomController = currentRoomController;
            currentRoomController = currentRoom.GetComponent<RoomController>();  // Updates 
            currentRoomController.playerPrefab = this.playerPrefab;  // pass player to the room.

            currentRoomNum++;
            cameraAtNewScene = false;
        }
    }

    private void CreateBossRoom() {
        // todo: this.
        Debug.Log("Boss Room Spawns");
    }

    // This is called when room is exited.
    private void GotoNextRoom() {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // Remove player.
        if(currentRoomController.playerScript.completedLevel == true) {
            if(currentRoomController.playerObject != null) 
                GameObject.Destroy(currentRoomController.playerObject);
            currentRoomController.playerScript.completedLevel = false;
            CreateRoom();
            lastRoomController.makeNextPlayer = true;
        }*/

        // create new room for camera to look at.
        if(currentRoomController.playerScript != null && currentRoomController.playerScript.completedLevel == true) {
            currentRoomController.playerScript.completedLevel = false;
            if(currentRoomController.playerObject != null) 
                GameObject.Destroy(currentRoomController.playerObject);
            CreateRoom();
        }

        // Camera slides over when not in room.
        if(camTrans.position.x < (currentRoomNum-1) * ROOM_WIDTH) {
            camTrans.Translate(Vector3.right * Time.deltaTime * CAMERA_SPEED);
        } else if(camTrans.position.x > (currentRoomNum-1) * ROOM_WIDTH) {
            camTrans.position = new Vector3((currentRoomNum-1) * ROOM_WIDTH, camTrans.position.y, camTrans.position.z);
        } else {  // case: camera is in the right position. 
            if(cameraAtNewScene == false) {
                // When camera gets there, create the new player.
                currentRoomController.CreatePlayer();
                //if(lastRoomController != null) lastRoomController.makeNextPlayer = false;
                cameraAtNewScene = true;
            }
        }

    }
}
