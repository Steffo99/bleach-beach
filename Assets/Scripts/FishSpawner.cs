using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {

    public float spawnTime = 5;
    public float randomFactor = 1;
    public GameObject fish;
    private float timeToSpawn;

	void Start () {
        timeToSpawn = Random.Range(spawnTime - randomFactor, spawnTime + randomFactor);
	}
	
	void Update () {
        timeToSpawn -= Time.deltaTime;
        if(timeToSpawn <= 0)
        {
            Instantiate(fish);
            timeToSpawn = Random.Range(spawnTime - randomFactor, spawnTime + randomFactor);
        }
	}
}
