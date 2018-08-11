using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tide : MonoBehaviour
{
    public BuoyancyEffector2D buoyancyEffector2D;
    public SpriteRenderer spriterenderer;
    float speed = 0.01f;
    // Use this for initialization
    void Start()
    {
        buoyancyEffector2D = GetComponent<BuoyancyEffector2D>();
        spriterenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buoyancyEffector2D.surfaceLevel > 0)
        {
            buoyancyEffector2D.surfaceLevel = buoyancyEffector2D.surfaceLevel - (Time.deltaTime * speed);
            float y = (buoyancyEffector2D.surfaceLevel * 40) - 10;
            Vector3 vettore = new Vector3(0.0f, y , 0.0f);
            spriterenderer.transform.position = vettore;
        }
    }
}