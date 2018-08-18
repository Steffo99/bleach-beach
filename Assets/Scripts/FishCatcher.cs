using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCatcher : MonoBehaviour {

    public int fishCaught = 0;
    public Sprite[] fishPileSprites;
    public int[] fishPileStages;
    public GameObject fishPile;

    private SpriteRenderer fishPileRenderer;

    private void Start()
    {
        fishPile = transform.Find("Fish Pile").gameObject;
        fishPileRenderer = fishPile.GetComponent<SpriteRenderer>();
        Camera.main.GetComponent<FollowGameObject>().target = gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FishAi fishAi = collision.gameObject.GetComponent<FishAi>();
        if (collision.gameObject.tag == "Fish" && fishAi.hook != null)
        {
            fishCaught += fishAi.value;
            Destroy(collision.gameObject);
            CheckStages();
        }
    }

    public void LoseFish()
    {
        fishCaught--;
        CheckStages();
    }

    private void CheckStages()
    {
        int currentStage = 0;
        while(true)
        {
            if (currentStage == fishPileStages.Length)
            {
                break;
            }
            if (fishCaught >= fishPileStages[currentStage])
            {
                currentStage++;
            }
            else break;
        }
        fishPileRenderer.sprite = fishPileSprites[currentStage];
    }
}
