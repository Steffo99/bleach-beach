using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invert : MonoBehaviour {

    public Shader shader;

	void Start () {
        Camera.main.SetReplacementShader(shader, "RenderType");
    }
}
