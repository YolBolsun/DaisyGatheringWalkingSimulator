using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour {

    public List<GameObject> enemies;
    public GameObject player;
    Player playerInfo;
    float lastSpawnDistance;

    public float spawnLikelihoodModifier = 1;
    float distanceToNextSpawn = 0;

    public float viewRadius;
    public float spawnRadius;

    public float verticalMaxSpawn;
    public float verticalMinSpawn;
	// Use this for initialization
	void Start () {
        playerInfo = player.GetComponent<Player>();
        lastSpawnDistance = playerInfo.TotalDistance;
        if(spawnRadius <= viewRadius)
        {
            Debug.Log("Error: spawnRadius should be larger than viewRadius");
        }
	}
	
	// Update is called once per frame
	void Update () {
        float newDistance = playerInfo.TotalDistance;
        if(distanceToNextSpawn + lastSpawnDistance < newDistance)
        {
            distanceToNextSpawn = Random.Range(0f, 1f)* spawnLikelihoodModifier;
            SpawnEnemy();
            lastSpawnDistance = newDistance;
        }
	}
    void SpawnEnemy()
    {
        float planeDirection = Random.Range(0, 360);
        float verticalDirection = Random.Range(verticalMinSpawn, verticalMaxSpawn);
        float spawnDistance = Random.Range(viewRadius, spawnRadius);

        float x = Mathf.Sin(Mathf.Deg2Rad * planeDirection) * spawnDistance + player.transform.position.x;
        float z = Mathf.Cos(Mathf.Deg2Rad * planeDirection) * spawnDistance + player.transform.position.z;
        float y = Mathf.Sin(Mathf.Deg2Rad * verticalDirection) * spawnDistance + player.transform.position.y;

        Vector3 spawnLoc = new Vector3(x, y, z);
        Debug.Log(spawnLoc);

        GameObject.Instantiate(enemies[Random.Range(0, enemies.Count - 1)],spawnLoc,Quaternion.identity);
    }
}
