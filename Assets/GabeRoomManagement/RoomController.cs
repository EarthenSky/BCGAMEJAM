using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// This class owns the player.
public class RoomController : MonoBehaviour
{
    //public bool makeNextPlayer = false;  // 
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject bossPrefab;

    public GameObject playerObject;
    public ControlsEdit playerScript;
    public GameObject background;
    public GameObject currRoom;
    public Sprite backgroundImg;
    public List<Transform> enemyPositions;  // preset things

    public bool isBossRoom = false;

    // Start is called before the first frame update
    void Start()
    { 
        //transform.Find("Grid").Find("Tilemap").gameObject.AddComponent<TilemapCollision>();
        
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
        if(!isBossRoom) {
            // instantiate an enemy in each position.
            foreach(Transform transform in enemyPositions) {
                GameObject tmpEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
                tmpEnemy.GetComponent<EnemyEdit>().player = playerObject; 
            }
        } else {
            Debug.Log("SPAWN BOSS!!");
            // instantiate an enemy in each position.
            foreach(Transform transform in enemyPositions) {
                GameObject tmpEnemy = Instantiate(bossPrefab, transform.position, Quaternion.identity, transform);
                tmpEnemy.GetComponent<BossEdit>().player = playerObject; 
            }
        }
        
    }

    //TODO: implement this.
    public void DestroyEnemies() {
        foreach(Transform t in enemyPositions) {
	       GameObject.Destroy(t.gameObject); // destroy the enemies.
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
