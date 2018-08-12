using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour {
    public Image image;
    public GameObject fade;

    private Animator animator;

    private void Start()
    {
        animator = fade.GetComponent<Animator>();
    }

    private void Update()
    {
        if (animator.GetBool("Finished"))
        {
            SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
        }
    }

    void OnTriggerEnter2D(Collider2D GameStart)
    {
        animator.SetBool("Fade", true);
    }
}
