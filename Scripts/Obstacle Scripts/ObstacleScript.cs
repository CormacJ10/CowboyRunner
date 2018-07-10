using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {
    //instance variables.
    private float speed = -3f;

    private Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        body.velocity = new Vector2(speed, 0f);
	}
}
