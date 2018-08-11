using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marea : MonoBehaviour {
    public BuoyancyEffector2D buoyancyEffector2D;
    float speed = 0.01f;
	// Use this for initialization
	void Start () {
        buoyancyEffector2D = GetComponent<BuoyancyEffector2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if(buoyancyEffector2D.surfaceLevel>0)
        {
            buoyancyEffector2D.surfaceLevel = buoyancyEffector2D.surfaceLevel - (Time.deltaTime * speed);
        }
	}
}
