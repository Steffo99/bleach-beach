using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour {
    
    public float startingTime = 500f;
    public GameObject script;
    private float currentTime = 500f;
    private Text timerText;

	void Start () {
        currentTime = startingTime;
        timerText = GetComponent<Text>();
	}
	
	void Update () {
        currentTime -= Time.deltaTime;
        timerText.text = string.Format("{0}:{1:00}", (int)currentTime / 60, (int)currentTime % 60);
        if(currentTime <= 0f)
        {
            TheEnd();
        }
	}

    void TheEnd()
    {
        FishCatcher presi;
        presi = script.GetComponent<FishCatcher>();
        int score = presi.fishCaught;
        Debug.Log(score);
        PlayerPrefs.SetInt("player_score", score);
        SceneManager.LoadSceneAsync("Results", LoadSceneMode.Single);
    }
}
