using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWithEsc : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.LogWarning("Application.Quit() is not available in the Unity Editor.");
            Application.Quit();
        }
	}
}
