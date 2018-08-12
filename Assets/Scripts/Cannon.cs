using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
    
    public bool harpoonAvailable = true;
    public GameObject harpoon;
    public float maxForce = 5f;
    public float forceBuildingSpeed = 2f;
    public float startingForce = 1f;
    private float force = 1f;

    public GameObject chain;

    private Linker chainLinker;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        chainLinker = chain.GetComponent<Linker>();        
    }

    private void Update ()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 direction = (Vector2)Input.mousePosition - screenPosition;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        spriteRenderer.flipX = direction.x < 0;
        if (harpoonAvailable)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                force = Mathf.Clamp(force + forceBuildingSpeed * Time.deltaTime, 0, maxForce);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                GameObject harpoonInstance = Instantiate(harpoon);
                harpoonInstance.transform.position = transform.position + (Vector3)direction.normalized;
                harpoonInstance.transform.rotation = transform.rotation;
                harpoonInstance.GetComponent<Rigidbody2D>().AddForce(direction * force);
                harpoonInstance.GetComponent<SpriteRenderer>().flipX = spriteRenderer.flipX;
                chainLinker.secondObject = harpoonInstance;
                force = startingForce;
                harpoonAvailable = false;
            }
        }
    }
}
