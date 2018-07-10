using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {
    //instance variable.
    public delegate void EndGame();
    public static event EndGame endGame;//So that it could be used on other scripts as object

	void PlayerDiedEndGame()
    {//If player dies, deactivates (destroys) everything.
        if (endGame != null)
        {
            endGame();
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D target)
    {//Obstacles Collector have trigger, player's and zombie's don't.
        if (target.tag == "Collector")
        {
            PlayerDiedEndGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {//Player dies if get hit by Zombie, player only looses momentum if get hit by obstacles.
        if (target.gameObject.tag == "Zombie")
        {
            PlayerDiedEndGame();
        }
    }
}
