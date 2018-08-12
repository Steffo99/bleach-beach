using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D GameStart)
    {
        Application.LoadLevel(1);
        Debug.Log("Hi Mark");

    }

}
