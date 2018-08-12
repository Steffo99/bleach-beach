using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour {

    public GameObject target;
    public Vector2 limitFirstCorner;
    public Vector2 limitSecondCorner;
    
    void Update () {
        if (target != null)
        {
            transform.position = new Vector3(
                Mathf.Clamp(target.transform.position.x, limitFirstCorner.x, limitSecondCorner.x),
                Mathf.Clamp(target.transform.position.y, limitFirstCorner.y, limitSecondCorner.y),
                -1f
            );
        }
	}
}
