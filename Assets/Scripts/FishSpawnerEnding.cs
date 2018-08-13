using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishSpawnerEnding : MonoBehaviour
{

    public float spawnTime = 5f;
    public float randomFactor = 1f;
    public GameObject fish;
    public GameObject sea;
    public Text punteggio;
    private float timeToSpawn;
    private int toSpawn;
    private int spawned = 0;

    void Start()
    {
        timeToSpawn = Random.Range(spawnTime - randomFactor, spawnTime + randomFactor);
        toSpawn = PlayerPrefs.GetInt("player_score");
    }

    void Update()
    {
        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn <= 0 && spawned < toSpawn)
        {
            GameObject newFish = Instantiate(fish);
            newFish.transform.position = transform.position;
            newFish.GetComponent<FishAi>().sea = sea;
            timeToSpawn = Random.Range(spawnTime - randomFactor, spawnTime + randomFactor);
            spawned++;
            punteggio.text = spawned.ToString();
        }
    }
}
