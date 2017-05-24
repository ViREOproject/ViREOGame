using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    //Enemy prefab to be spawned
    public GameObject[] enemy;
    //Time between each spawn
    public float spawnTime = 2f;
    //Array of spawn points this enemy can spawn from
    public Transform[] spawnPoints;


	// Use this for initialization
	void Start () {

        
        InvokeRepeating("Spawn", spawnTime, spawnTime);
		
	}
	
	void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        //Instantiate(enemy, new Vector3(47,0,55), spawnPoints[spawnPointIndex].rotation);
        int enemyIndex = Random.Range(0, enemy.Length);

        /** Limit the number of enemies on the screen
         *  Allows for 5 Ghosts and 3 Witches
         */
        if (GameObject.FindGameObjectsWithTag(enemy[enemyIndex].tag).Length < 5 && enemyIndex == 0) //Ghost
        {
            Debug.Log("Ghost");
            GameObject ghost = Instantiate(enemy[enemyIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            //set the ghost to use the scale set in options scene
            ghost.transform.localScale = GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>().getGhostScale();
            //ghost.transform.localScale = new Vector3(200, 200, 200);
        }
        else if(GameObject.FindGameObjectsWithTag(enemy[enemyIndex].tag).Length < 3 && enemyIndex == 1) //Witch
        {
            Debug.Log("Witch");
            GameObject witch = Instantiate(enemy[enemyIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            //set the witch to use the scale set in options scene
            witch.transform.localScale = GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>().getWitchScale();
            //witch.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        /** Limit the number of enemies on the screen
         *  Allows for 5 Ghosts and 5 Witches
         */
        //if (GameObject.FindGameObjectsWithTag(enemy[enemyIndex].tag).Length < 5)
        //{
        //    Instantiate(enemy[enemyIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        //}
        
    }
}
