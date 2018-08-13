using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;
    public GameObject hull;
    public float horizontalShipSpeed = 5f;
    public float verticalShipSpeed = 30;
    public float maxJetFuel = 2f;
    public float jetFuelRechargeSpeed = 0.1f;
    private float jetFuel;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        jetFuel = maxJetFuel;
	}
	
	void FixedUpdate () {
        if (Input.GetAxis("Horizontal") < 0)
        {
            hull.transform.localScale = new Vector3(-1, 1, 1);
            rb.AddForce(Vector2.right * -horizontalShipSpeed);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            hull.transform.localScale = new Vector3(1, 1, 1);
            rb.AddForce(Vector2.right * horizontalShipSpeed);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            if (jetFuel > 0f)
            {
                jetFuel = Mathf.Clamp(jetFuel - Time.deltaTime, 0, maxJetFuel);
                rb.AddForce(Vector2.up * verticalShipSpeed);
            }
        }
        else
        {
            jetFuel = Mathf.Clamp(jetFuel + Time.deltaTime, 0, maxJetFuel);
        }
    }
}
