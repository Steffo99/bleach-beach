using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitCrosshair : MonoBehaviour {

    public Texture2D crosshair;

	void Start () {
        Cursor.SetCursor(crosshair, new Vector2(15, 14), CursorMode.Auto);
	}
}
