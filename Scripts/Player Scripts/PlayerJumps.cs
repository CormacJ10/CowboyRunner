using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerJumps : MonoBehaviour {
    //instance variables.
    [SerializeField]
    private AudioClip jumpClip;

    private float jumpForce = 12f, forwardForce=0f;

    private Rigidbody2D body;


    private bool canJump;

    private Button jumpBtn;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();

        jumpBtn = GameObject.Find("JumpButton").GetComponent<Button>();

        jumpBtn.onClick.AddListener(() => Jump());
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(body.velocity.y) == 0)//Absolute value always returns a positive value.
        {//Checks if the floating point of game object, in y-position, is 0, player can jump.
            canJump = true;
        }
	}

    public void Jump()
    {
        if (canJump)
        {
            canJump = false;

            //AudioSource.PlayClipAtPoint(jumpClip, transform.position);

            if (transform.position.x < 0)
            {//Moves the player forward.
                forwardForce = 1f;
            }
            else
            {//Player jumps
                forwardForce = 0f;
            }

            //Player jumps up by about 12 pixels high.
            body.velocity = new Vector2(forwardForce, jumpForce);
        }
    }
}
