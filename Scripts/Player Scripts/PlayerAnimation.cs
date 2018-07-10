using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    //instance variables.
    private Animator anim;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}

    private void OnCollisionEnter2D(Collision2D target)
    {//If player gets hit by object, stays in idle anim. until player recovers.
        if (target.gameObject.tag == "Obstacle")
        {
            anim.Play("Idle");
        }
    }

    private void OnCollisionExit2D(Collision2D target)
    {//If player "avoids" object, continue run animation.
        if (target.gameObject.tag == "Obstacle")
        {
            anim.Play("Run");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
