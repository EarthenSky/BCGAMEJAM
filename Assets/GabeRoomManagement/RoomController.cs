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
    public GameObject background;
    public GameObject currRoom;
    public Sprite backgroundImg;
    public List<Transform> enemyPositions;  // preset things

    // Start is called before the first frame update
    void Start()
    { 
        currRoom = GameObject.Find("RoomManager").GetComponent<RoomManager>().currentRoom;
        background = new GameObject("Background");
        background.AddComponent<SpriteRenderer>();
        background.GetComponent<SpriteRenderer>().sprite = backgroundImg;
        background.transform.parent = currRoom.transform;
        background.transform.localScale = new Vector3(2.7f, 2.3f, 0);
        background.transform.localPosition = new Vector3(0, 0, 10f);
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
            GameObject tmpEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
            tmpEnemy.GetComponent<EnemyEdit>().player = playerObject; 
        }
    }

    //TODO: implement this.
    public void DestroyEnemies() {
        foreach(Transform t in enemyPositions) {
	       Destroy(t.GetChild(0).gameObject); // destroy the enemies.
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
