using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class pointsSpawner : MonoBehaviour
{
    // point ball
    public GameObject point;

    //Environment GameObject
    private GameObject environmentGM;

    //spawner range 
    private float spawnerRadius;

    //spawn rate
    public float spawnRate;

    //max num of point
    public int maxNumOfPoint;


    // Start is called before the first frame update
    void Start()
    {
        
        //get radius of range if height(x) of playgroung of box equil its weight(z)
        spawnerRadius = (GameObject.FindGameObjectWithTag("PlayGround").transform.localScale.x)/2;

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
        int countOfSpawnedPoint = GameObject.FindGameObjectsWithTag("Point").Length;
        //ensure that there are not much points than decided
        if (countOfSpawnedPoint<maxNumOfPoint) {
            //get random position to spawn the point ball using it
            float xAxis = (float)Random.Range(spawnerRadius, -spawnerRadius);
            float zAxis = (float)Random.Range(spawnerRadius, -spawnerRadius);

            //spawn the point gameobject and make it a child of Environment GameObject
            GameObject pointGM = Instantiate(point, new Vector3(xAxis, transform.position.y, zAxis), Quaternion.Euler(0, 0, 0));
            pointGM.transform.SetParent(environmentGM.transform);
        }
    }
}
