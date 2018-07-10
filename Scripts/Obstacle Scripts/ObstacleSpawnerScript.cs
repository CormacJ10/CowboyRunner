using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerScript : MonoBehaviour {
    //instance variables.
    [SerializeField]
    private GameObject[] obstacles;

    private List<GameObject> obstaclesForSpawning = new List<GameObject>();//Much more flexible than arrays.

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnRandomObstacle());//Starts Coroutine.
    }

    private void Awake()
    {//Initializes upon game loading.
        InitializeObstacles();
    }

    void InitializeObstacles()
    {
        int index = 0;
        for(int i=0; i<obstacles.Length*3; i++)
        {//Because we want to add the obstacles 3 times in the list.
            GameObject obj = Instantiate(obstacles[index], new Vector3(transform.position.x, transform.position.y, -2), Quaternion.identity) as GameObject;//Casting instantiated obstacle, from array, to game object.

            obstaclesForSpawning.Add(obj);
            obstaclesForSpawning[i].SetActive(false);//Object is inactive until we get it near towards the player.

            index++;
            if (index == obstacles.Length)
            {//If index equals 3, reset to 0 to prevent IndexOutOfBounds Exception.
                index = 0;
            }
        }
    }

    void Shuffle()
    {
        for(int j=0; j<obstaclesForSpawning.Count; j++)
        {
            GameObject temp = obstaclesForSpawning[j];
            int randIndex = Random.Range(j, obstaclesForSpawning.Count);


            //Shuffles obstacle with a random one from the list.
            obstaclesForSpawning[j] = obstaclesForSpawning[randIndex];
            obstaclesForSpawning[randIndex] = temp;
        }
    }

    //Coroutine
    IEnumerator SpawnRandomObstacle()
    {
        //Random Spawn Rate
        yield return new WaitForSeconds(Random.Range(1.5f, 4.5f));

        int index = Random.Range(0, obstaclesForSpawning.Count);
        while (true)
        {
            if (!(obstaclesForSpawning[index].activeInHierarchy))
            {//Set an object to active that hasn't been activated from list.
                obstaclesForSpawning[index].SetActive(true);
                obstaclesForSpawning[index].transform.position = new Vector3(transform.position.x, transform.position.y, -2);// Sets to same spawn location.
                break;
            }
            else
            {//Otherwise, find a new random object that hasn't been activated yet.
                index = Random.Range(0, obstaclesForSpawning.Count);
            }
        }

        StartCoroutine(SpawnRandomObstacle());//Starts Coroutine.
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
