using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// This class has authority over The rooms the player's prefab.
/// 
public class RoomManager : MonoBehaviour
{
    const float CAMERA_SPEED = 40f;
    const float CAMERA_ZOOM_SPEED = 0.25f;

    const int ROOM_WIDTH = 42;
    const int ROOM_HEIGHT = 24;
    //const int ROOM_COUNT = 2; //set back to 10 later
    public const int ROOM_COUNT = 2;

    const int CAMERA_ZOOM_NORMAL = 12;
    public int currentRoomNum = 0;
    public int currentRoomSize = CAMERA_ZOOM_NORMAL;
    public List<GameObject> rooms;
    public GameObject bossRoom;
    public AudioClip bossMusic;
    public Sprite bossBG;

    public int savedHealth = 100;
    
    public GameObject currentRoom;
    public RoomController currentRoomController;
    public GameObject lastRoom;
    public RoomController lastRoomController;
    
    public Transform camTrans;
    public Camera mainCam;
    public GameObject playerPrefab;
    public GameObject soundGameObject;
    public Sprite bgSprite;
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
        if(currentRoomNum >= ROOM_COUNT) { // Spawn boss room if in last room.
            CreateBossRoom();
        } else {  // Spawn current room
            // Delete last room
            if(lastRoom != null) GameObject.Destroy(lastRoom);  // Remove the old room.

            // Make a new room.
            lastRoom = currentRoom;
            currentRoom = GetRandomRoom();
            currentRoom = Instantiate(currentRoom, new Vector3(ROOM_WIDTH * currentRoomNum, 0, 0), Quaternion.identity);
            
            // Get script portion of the room.
            lastRoomController = currentRoomController;
            currentRoomController = currentRoom.GetComponent<RoomController>();  // Updates 
            currentRoomController.playerPrefab = this.playerPrefab;  // pass player to the room.
            currentRoomController.backgroundImg = this.bgSprite; //pass background sprite to the room
        }

        currentRoomNum++;
        cameraAtNewScene = false;
    }

    private void CreateBossRoom() {
        Debug.Log("Boss Room Spawns");

        // Delete last room
        if(lastRoom != null) GameObject.Destroy(lastRoom);  // Remove the old room.

        // Make a new room.
        currentRoomSize = currentRoomSize * 2;
        lastRoom = currentRoom;
        currentRoom = bossRoom;  // Get new room
        currentRoom = Instantiate(bossRoom, new Vector3(ROOM_WIDTH * (currentRoomNum+1), 0, 0), Quaternion.identity);
        
        // Get script portion of the room.
        lastRoomController = currentRoomController;
        currentRoomController = currentRoom.GetComponent<RoomController>();  // Updates 
        currentRoomController.playerPrefab = this.playerPrefab;  // pass player to the room.
        currentRoomController.backgroundImg = this.bossBG; //pass background sprite to the room

        //add the boss music to the boss room
        AudioSource SoundPlayer = soundGameObject.GetComponent<AudioSource>(); 
        SoundPlayer.clip = bossMusic;

        SoundPlayer.Play();
    }

/*
    // This is called when room is exited.
    private void GotoNextRoom() {
        
    }
*/
    // Update is called once per frame
    void Update()
    {
        // create new room for camera to look at.
        if(currentRoomController.playerScript != null && currentRoomController.playerScript.completedLevel == true) {
            currentRoomController.playerScript.completedLevel = false;
            if(currentRoomController.playerObject != null) {
                savedHealth = currentRoomController.playerObject.GetComponent<PlayerHealthEdit>().health;
                GameObject.Destroy(currentRoomController.playerObject);
                currentRoomController.DestroyEnemies();
            }

            CreateRoom();
            currentRoomController.isBossRoom = ((currentRoomNum-1) >= ROOM_COUNT);
        }


        // Camera slides over when not in room.
        float mod = ((currentRoomNum-1) >= ROOM_COUNT ? ROOM_WIDTH : 0);
        if(camTrans.position.x < (currentRoomNum-1) * ROOM_WIDTH + mod) {
            camTrans.Translate(Vector3.right * Time.deltaTime * CAMERA_SPEED);
        } else if(camTrans.position.x > (currentRoomNum-1) * ROOM_WIDTH + mod) {
            camTrans.position = new Vector3((currentRoomNum-1) * ROOM_WIDTH + mod, camTrans.position.y, camTrans.position.z);
        } else {  // case: camera is in the right position. 
            if(cameraAtNewScene == false) {
                // When camera gets there, create the new player.
                currentRoomController.CreatePlayer(savedHealth);
                currentRoomController.CreateEnemies();
                cameraAtNewScene = true;
            }
        }

        // Do camera zoom
        if(mainCam.orthographicSize < currentRoomSize) {
            mainCam.orthographicSize += CAMERA_ZOOM_SPEED;
        } else if(mainCam.orthographicSize > currentRoomSize) {
            mainCam.orthographicSize = currentRoomSize;
        } 

    }
}
