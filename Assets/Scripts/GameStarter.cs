using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour {
    public Image image;
    public Animator animator;

    void OnTriggerEnter2D(Collider2D GameStart)
    {
        animator.SetBool("Fade", false);
        Application.LoadLevel(1);
    }
}
