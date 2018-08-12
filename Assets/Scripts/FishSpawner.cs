using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {

    public float spawnTime = 5f;
    public float randomFactor = 1f;
    public GameObject fish;
    public GameObject sea;
    private float timeToSpawn;

	void Start () {
        timeToSpawn = Random.Range(spawnTime - randomFactor, spawnTime + randomFactor);
	}
	
	void Update () {
        timeToSpawn -= Time.deltaTime;
        if(timeToSpawn <= 0)
        {
            GameObject newFish = Instantiate(fish);
            newFish.transform.position = transform.position;
            newFish.GetComponent<FishAi>().sea = sea;
            timeToSpawn = Random.Range(spawnTime - randomFactor, spawnTime + randomFactor);
        }
        if(transform.position.y > sea.transform.position.y)
        {
            enabled = false;
        }
	}
}
