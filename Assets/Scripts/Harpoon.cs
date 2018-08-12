using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour {

    private Rigidbody2D rigidbody2D;
    private bool going = true;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update () {
        if(going)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, rigidbody2D.velocity.normalized);
        }
        else
        {

        }
	}
}
