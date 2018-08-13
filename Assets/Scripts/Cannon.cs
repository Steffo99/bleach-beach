using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
    
    public bool harpoonAvailable = true;
    public GameObject harpoon;
    public GameObject hull;
    public float maxForce = 5f;
    public float forceBuildingSpeed = 2f;
    public float startingForce = 1f;
    private float force = 1f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Disable enemy and player collisions
        Physics2D.IgnoreLayerCollision(8, 8);
        Physics2D.IgnoreLayerCollision(9, 9);
    }

    private void Update ()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 direction = (Vector2)Input.mousePosition - screenPosition;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        spriteRenderer.flipX = !((direction.x < 0) ^ (hull.transform.localScale.x > 0));
        if (harpoonAvailable)
        {
            if (Input.GetMouseButton(0))
            {
                force = Mathf.Clamp(force + forceBuildingSpeed * Time.deltaTime, 0, maxForce);
            }
            if (Input.GetMouseButtonUp(0))
            {
                GameObject harpoonInstance = Instantiate(harpoon);
                harpoonInstance.transform.position = transform.position + (Vector3)direction.normalized;
                harpoonInstance.transform.rotation = transform.rotation;
                harpoonInstance.GetComponent<Rigidbody2D>().AddForce(direction * force);
                harpoonInstance.GetComponent<SpriteRenderer>().flipX = spriteRenderer.flipX;
                harpoonInstance.layer = 8;
                Linker linker = harpoonInstance.GetComponentInChildren<Linker>();
                linker.firstObject = gameObject;
                linker.secondObject = harpoonInstance;
                force = startingForce;
                harpoonAvailable = false;
            }
        }
        float scale = 1f + (((force - startingForce) / (maxForce - startingForce)) * 0.5f);
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
