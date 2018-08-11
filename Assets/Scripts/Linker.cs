using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linker : MonoBehaviour
{
    public GameObject firstObject;
    public GameObject secondObject;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update () {
        lineRenderer.SetPosition(0, firstObject.transform.position);
        lineRenderer.SetPosition(1, secondObject.transform.position);
    }
}
