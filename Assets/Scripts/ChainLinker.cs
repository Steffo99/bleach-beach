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
        GameObject tailInstance = Instantiate(tail, transform);
        GameObject nextChain = Instantiate(chain, transform);
        nextChain.transform.position = tailInstance.transform.position + tailOffset;
        tailInstance.GetComponent<HingeJoint2D>().connectedBody = nextChain.GetComponent<Rigidbody2D>();
        for(int i = 0; i < chainNumber - 1; i++)
        {
            GameObject lastChain = nextChain;
            nextChain = Instantiate(chain, transform);
            nextChain.transform.position = lastChain.transform.position + chainOffset;
            lastChain.GetComponent<HingeJoint2D>().connectedBody = nextChain.GetComponent<Rigidbody2D>();
        }
	}
}
