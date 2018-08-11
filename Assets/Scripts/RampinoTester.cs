using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampinoTester : MonoBehaviour
{

    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 20f);
        }
    }
}
