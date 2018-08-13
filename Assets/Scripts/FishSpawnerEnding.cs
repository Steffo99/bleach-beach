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
    public Text winner;
    private float timeToSpawn;
    private int toSpawn;
    private int spawned = 0;
    private string vincitore = "";

    void Start()
    {
        timeToSpawn = Random.Range(spawnTime - randomFactor, spawnTime + randomFactor);
        toSpawn = PlayerPrefs.GetInt("player_score");
        vincitore = PlayerPrefs.GetString("winner");
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
        if (spawned >= toSpawn)
        {
            winner.text = vincitore;
        }
    }
}
