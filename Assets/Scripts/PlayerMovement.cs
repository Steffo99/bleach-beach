using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D rb;
    public float horizontalShipSpeed = 50;
    public float verticalShipSpeed = 20;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            if(Input.GetKey(KeyCode.RightShift))
            { 
                rb.AddTorque(horizontalShipSpeed);
            }
            else
            {
                rb.AddForce(Vector2.right * -horizontalShipSpeed);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
            if (Input.GetKey(KeyCode.RightShift))
            {
                rb.AddTorque(-horizontalShipSpeed);
            }
            else
            {
                rb.AddForce(Vector2.right * horizontalShipSpeed);
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up * verticalShipSpeed);
        }
    }
}
