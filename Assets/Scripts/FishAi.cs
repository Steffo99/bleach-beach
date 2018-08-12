using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAi : MonoBehaviour {

    public float timeBetweenDirectionChanges = 1f;
    public float speed = 2f;
    public GameObject hook = null;
    public GameObject sea;
    private Vector3 direction;
    private Rigidbody2D rigidbody2D;

	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        InvokeRepeating("ChangeDirection", 0, timeBetweenDirectionChanges);
	}

    void ChangeDirection()
    {
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
	
	void Update () {
        if (hook == null)
        {
            if (transform.position.y > sea.transform.position.y)
            {
                direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-4f, -2f));
            }
            rigidbody2D.MovePosition(transform.position + direction * Time.deltaTime * speed);
        }
        else
        {
            rigidbody2D.MovePosition(hook.transform.position);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeDirection();
    }
}
