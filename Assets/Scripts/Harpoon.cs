using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour {

    public float returnSpeed = 5f;

    private Rigidbody2D rigidbody2D;
    private bool going = true;
    private Linker linker;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        linker = GetComponentInChildren<Linker>();
    }

    void Update ()
    {
        if(going)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, rigidbody2D.velocity.normalized);
        }
        else
        {
            if (transform.position.y > linker.firstObject.transform.position.y)
            {

                rigidbody2D.MoveRotation(Vector2.Angle(transform.position - linker.firstObject.transform.position, Vector2.right) - 90f);
            }
            else
            {

                rigidbody2D.MoveRotation(-Vector2.Angle(transform.position - linker.firstObject.transform.position, Vector2.right) - 90f);
            }
            rigidbody2D.MovePosition(Vector3.MoveTowards(transform.position, linker.firstObject.transform.position, returnSpeed * Time.deltaTime));
            if(Vector3.Distance(transform.position, linker.firstObject.transform.position) < 0.2f)
            {
                linker.firstObject.GetComponent<Cannon>().harpoonAvailable = true;
                Destroy(gameObject);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        going = false;
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
    }
}
