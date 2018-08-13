using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipAi : MonoBehaviour {

    public float maximumDistanceFromFish = 2f;
    public float timeBeforeChangingTarget = 10f;
    public float horizontalSpeed = 5f;
    public float verticalSpeed = 30f;
    public float shootForce = 5f;
    public GameObject harpoon;
    public bool harpoonAvailable = true;
    public float maxJetFuel = 2f;
    public float jetFuelRechargeSpeed = 0.1f;

    private GameObject target = null;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float timeSinceLastTarget = 0f;
    private float jetFuel;
    private bool usingJet;
    
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jetFuel = maxJetFuel;
	}
	
	void Update () {
        timeBeforeChangingTarget += Time.deltaTime;
        //Find a target fish
		if(target == null || timeSinceLastTarget > timeBeforeChangingTarget)
        {
            if(target != null)
            {
                target.GetComponent<FishAi>().targetedBy = null;
            }
            target = FindClosestFish(GameObject.FindGameObjectsWithTag("Fish"));
            if (target != null)
            {
                target.GetComponent<FishAi>().targetedBy = gameObject;
            }
            timeBeforeChangingTarget = 0f;
        }
    }

    void FixedUpdate()
    {
        //If the bot has a target
        if(target != null)
        {
            //Slow down when near the fish
            float power = Mathf.Clamp((Mathf.Abs(transform.position.x - target.transform.position.x) / maximumDistanceFromFish) - 1f, 0f, 1f);
            //Shoot an harpoon if it's close enough and it's available
            if (power == 0f && harpoonAvailable)
            {
                //Disable the jetpack
                usingJet = false;
                //Find the direction between the fish and the ship
                Vector3 direction = (target.transform.position - transform.position).normalized; 
                //Shoot the harpoon
                GameObject harpoonInstance = Instantiate(harpoon);
                harpoonInstance.transform.position = transform.position + direction;
                harpoonInstance.transform.rotation = transform.rotation;
                harpoonInstance.GetComponent<Rigidbody2D>().AddForce(direction * shootForce);
                harpoonInstance.GetComponent<SpriteRenderer>().flipX = spriteRenderer.flipX;
                harpoonInstance.layer = 9;
                Linker linker = harpoonInstance.GetComponentInChildren<Linker>();
                linker.firstObject = gameObject;
                linker.secondObject = harpoonInstance;
                harpoonAvailable = false;
            }
            //Apply a force towards that direction if too far away
            else
            {
                //Right
                if (transform.position.x - target.transform.position.x < 0f)
                {
                    rb.AddForce(Vector2.right * horizontalSpeed * power);
                    spriteRenderer.flipX = true;
                }
                //Left
                else
                {
                    rb.AddForce(Vector2.right * -horizontalSpeed * power);
                    spriteRenderer.flipX = false;
                }
                //Enable the jetpack
                if(jetFuel == maxJetFuel)
                {
                    usingJet = true;
                }
                //Use the jetpack
                if(usingJet)
                {
                    jetFuel -= Time.fixedDeltaTime;
                    rb.AddForce(Vector2.up * verticalSpeed);
                    if(jetFuel <= 0)
                    {
                        usingJet = false;
                    }
                }
                else
                {
                    jetFuel = Mathf.Clamp(jetFuel + Time.fixedDeltaTime * jetFuelRechargeSpeed, 0f, maxJetFuel);
                }
            }
        }
    }

    GameObject FindClosestFish(GameObject[] fish)
    {
        GameObject result = null;
        float minimumDistance = Mathf.Infinity;
        foreach (GameObject fishInstance in fish)
        {
            if (fishInstance.GetComponent<FishAi>().targetedBy != null) continue;
            float distance = Vector3.Distance(fishInstance.transform.position, transform.position);
            if (distance < minimumDistance)
            {
                minimumDistance = distance;
                result = fishInstance;
            }
        }
        return result;
    }

}
