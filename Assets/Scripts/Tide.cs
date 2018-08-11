using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tide : MonoBehaviour {

    private BuoyancyEffector2D buoyancyEffector2D;
    public float speed = 0.01f;

	void Start () {
        buoyancyEffector2D = GetComponent<BuoyancyEffector2D>();
    }
	
	void Update () {
        if(buoyancyEffector2D.surfaceLevel > 0)
        {
            buoyancyEffector2D.surfaceLevel = buoyancyEffector2D.surfaceLevel - (Time.deltaTime * speed);
        }
	}
}
