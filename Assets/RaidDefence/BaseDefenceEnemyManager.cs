using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseDefenceEnemyManager : MonoBehaviour {

    public List<GameObject> enemiesToSpawn = new List<GameObject>();


    public float spawnRate;
    public float spawnRateRandomness;

    public float minSpawnX;
    public float maxSpawnX;
    public float minSpawnY;
    public float maxSpawnY;

    Transform player;
    float nextSpawn = 2;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.timeSinceLevelLoad > nextSpawn)
        {
            nextSpawn = (Random.value - 1) * spawnRateRandomness + spawnRate + Time.timeSinceLevelLoad;
            GameObject.Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Count)],
                new Vector3(player.position.x+Random.Range(minSpawnX,maxSpawnX),player.position.y+Random.Range(minSpawnY,maxSpawnY),player.position.z),Quaternion.identity);
        }
	    
	}
}
