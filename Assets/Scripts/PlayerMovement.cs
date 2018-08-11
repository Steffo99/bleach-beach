using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;
    public GameObject hull;
    public float horizontalShipSpeed = 50;
    public float verticalShipSpeed = 20;
    public float maxJetFuel = 2f;
    public float jetFuelRechargeSpeed = 0.5f;
    private float jetFuel;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        jetFuel = maxJetFuel;
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
        if (Input.GetKey(KeyCode.UpArrow) && jetFuel > 0f)
        {
            jetFuel = Mathf.Clamp(jetFuel - Time.deltaTime, 0, maxJetFuel);
            rb.AddForce(Vector2.up * verticalShipSpeed);
        }
        else if(!Input.GetKey(KeyCode.UpArrow))
        {
            jetFuel = Mathf.Clamp(jetFuel + Time.deltaTime, 0, maxJetFuel);
        }
    }
}
