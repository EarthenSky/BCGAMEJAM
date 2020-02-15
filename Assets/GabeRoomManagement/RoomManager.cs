using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    const int ROOM_COUNT = 10;
    public int current_room = 0;
    public List<GameObject> rooms;
    
    public GameObject player;

    void Start()
    {
        rooms = new List<GameObject>();
    }

    // todo: have random unused room.
    private GameObject GetRandomRoom() {
        int rand = Random.Range(0, rooms.Count);
        return rooms[rand];
    }

    // This is called when room is exited.
    private void GotoNextRoom() {
        GameObject room = GetRandomRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
