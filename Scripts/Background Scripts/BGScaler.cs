using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var height = Camera.main.orthographicSize * 2f;//Height Scale of quad.
        var width = height * Screen.width / Screen.height;

        if (gameObject.name == "Background")
        {
            transform.localScale = new Vector3(width, height, -2);//Scales BG resolution to screen size.
        }
        else
        {
            transform.localScale = new Vector3(width + 3f, 5, -2);//Scales Ground to 1/5th of screen resolution.
        }
	}
}
