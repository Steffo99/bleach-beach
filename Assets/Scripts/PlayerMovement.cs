using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;
    public GameObject hull;
    public float horizontalShipSpeed = 50;
    public float verticalShipSpeed = 20;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hull.transform.localScale = new Vector3(-1, 1, 1);
            rb.AddForce(Vector2.right * -horizontalShipSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            hull.transform.localScale = new Vector3(1, 1, 1);
            rb.AddForce(Vector2.right * horizontalShipSpeed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * verticalShipSpeed);
        }
    }
}
