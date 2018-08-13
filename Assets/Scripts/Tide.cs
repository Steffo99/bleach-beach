using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tide : MonoBehaviour
{
    public GameObject seaTextures;
    public float speed = 0.01f;

    private BuoyancyEffector2D buoyancyEffector2D;

    void Start()
    {
        buoyancyEffector2D = GetComponentInChildren<BuoyancyEffector2D>();
    }
    
    void Update()
    {
        if (buoyancyEffector2D.surfaceLevel > 0)
        {
            buoyancyEffector2D.surfaceLevel = buoyancyEffector2D.surfaceLevel - (Time.deltaTime * speed);
        }
        seaTextures.transform.Translate(Vector3.down * Time.deltaTime * speed * 40);
    }
}