using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCatcher : MonoBehaviour {

    public int fishCaught = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Fish")
        {
            fishCaught++;
            Destroy(collision.gameObject);
        }
    }
}
