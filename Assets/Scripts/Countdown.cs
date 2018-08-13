using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {
    
    public float startingTime = 500f;

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
        //Do something
    }
}
