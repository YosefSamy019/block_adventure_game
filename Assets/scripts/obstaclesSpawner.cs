using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclesSpawner : MonoBehaviour
{
    // point ball
    public GameObject obstacle;

    //Environment GameObject
    private GameObject environmentGM;

    //spawner range 
    private float spawnerRadius;

    //spawn rate
    public float spawnRate;

    //max num of Obstacles
    public int maxNumOfObstacles;



    // Start is called before the first frame update
    void Start()
    {
        //ensure this spawner can spawn or i destroy this component
        if (PlayerPrefs.HasKey("spawn obstacles") == true)
        {
            if (PlayerPrefs.GetString("spawn obstacles") == "false")
            {
                Destroy(this.gameObject.GetComponent<obstaclesSpawner>());
            }
        }

        

        //get radius of range if height(x) of playgroung of box equil its weight(z)
        spawnerRadius = (GameObject.FindGameObjectWithTag("PlayGround").transform.localScale.x) / 2;

        //declare the value of environmentGM && get the Environment GameObject
        environmentGM = GameObject.FindGameObjectWithTag("Environment");

        InvokeRepeating("spawn", 0.5f, spawnRate);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawn()
    {
        int countOfSpawnedObstacles = GameObject.FindGameObjectsWithTag("Obstacle").Length;
        //ensure that there are not much points than decided

        if (countOfSpawnedObstacles < maxNumOfObstacles)
        {
            //get random position to spawn the obstacle using it
            float xAxis = (float)Random.Range(spawnerRadius, -spawnerRadius);
            float zAxis = (float)Random.Range(spawnerRadius, -spawnerRadius);

            //spawn the obstacle gameobject and make it a child of Environment GameObject
            GameObject pointGM = Instantiate(obstacle, new Vector3(xAxis, transform.position.y, zAxis), Quaternion.Euler(0, 0, 0));
            pointGM.transform.SetParent(environmentGM.transform);

        }
    }
}
