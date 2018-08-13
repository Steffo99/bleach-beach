using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour {
    
    public float startingTime = 500f;
    public GameObject script;
    public GameObject nave1;
    public GameObject nave2;
    public GameObject nave3;
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
        FishCatcher presi, ai1, ai2, ai3;
        presi = script.GetComponent<FishCatcher>();
        ai1 = nave1.GetComponent<FishCatcher>();
        ai2 = nave2.GetComponent<FishCatcher>();
        ai3 = nave3.GetComponent<FishCatcher>();
        int ai = ai1.fishCaught + ai2.fishCaught + ai3.fishCaught;
        int score = presi.fishCaught;
        string vincitore = "Player";
        if(ai > score)
        {
                vincitore = "AI";
        }
        Debug.Log(score);
        Debug.Log(vincitore);
        Debug.Log(ai);
        PlayerPrefs.SetInt("player_score", score);
        PlayerPrefs.SetString("winner", vincitore);
        SceneManager.LoadSceneAsync("Results", LoadSceneMode.Single);
    }
}
