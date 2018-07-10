using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour {
    //instance variables.
    public float speed = 0.1f;

    private Vector2 offset = new Vector2(0, 0);
    private Material mat;

	// Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>().material;//Gets material from quad.
        offset = mat.GetTextureOffset("_MainTex");
	}
	
	// Update is called once per frame
	void Update () {//Loops the background/Ground according to the speed and offset.
        offset.x += speed * Time.deltaTime;
        mat.SetTextureOffset("_MainTex", offset);
	}
}
