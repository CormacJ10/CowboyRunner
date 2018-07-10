using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleOffScreen : MonoBehaviour {

    //Deactives all objects that go offscreen.
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Collector")
        {
            gameObject.SetActive(false);
        }
    }
}
