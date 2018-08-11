using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    public float rotationSpeed;

	void Update () {
		if(Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed);
        }
    }
}
