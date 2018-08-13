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
        fishPileRenderer = fishPile.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fish" && collision.gameObject.GetComponent<FishAi>().hook != null)
        {
            fishCaught++;
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
            if (fishCaught > fishPileStages[currentStage])
            {
                currentStage++;
            }
            else break;
        }
        fishPileRenderer.sprite = fishPileSprites[currentStage];
    }
}
