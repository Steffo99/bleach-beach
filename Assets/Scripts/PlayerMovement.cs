using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D rigidbody;
    public float horizontalShipSpeed = 35;
    public float verticalShipSpeed = 10;

    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddForce(Vector2.left * horizontalShipSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddForce(Vector2.right * horizontalShipSpeed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody.AddForce(Vector2.up * verticalShipSpeed);
        }
    }
}
