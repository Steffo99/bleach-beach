using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLinker : MonoBehaviour {

    public GameObject chain;
    public GameObject tail;
    public Vector3 chainOffset;
    public Vector3 tailOffset;
    public int chainNumber;
    
	void Start () {
        GameObject lastChain = null;
        GameObject nextChain = null;

        for(int i = 0; i < chainNumber - 1; i++)
        {
            if (i > 0)
            {
                lastChain = nextChain;
            }
            if (i == chainNumber - 2)
            {
                nextChain = Instantiate(tail, transform);
                nextChain.transform.position = lastChain.transform.position + tailOffset;
            }
            else
            {
                nextChain = Instantiate(chain, transform);
                if (lastChain != null)
                {
                    nextChain.transform.position = lastChain.transform.position + chainOffset;
                }
                else
                {
                    nextChain.transform.position = transform.position;
                }
            }
            if (lastChain != null)
            {
                nextChain.GetComponent<HingeJoint2D>().connectedBody = lastChain.GetComponent<Rigidbody2D>();
            }
            else
            {
                nextChain.GetComponent<HingeJoint2D>().connectedBody = GetComponentInParent<Rigidbody2D>();
            }
        }
	}
}
