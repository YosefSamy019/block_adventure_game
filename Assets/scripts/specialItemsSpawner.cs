using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialItemsSpawner : MonoBehaviour
{
    //this array contains special items gm
    public GameObject[] specialItemsGmArray;

    //this array contains spawning locations
    public Transform[] spawningLocationsArray;

    //time that spawner wait before spawning a special item
    public float waitingTimeBeforeSpawning;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnRandomItem",waitingTimeBeforeSpawning,waitingTimeBeforeSpawning);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //this function spawn random item
    void spawnRandomItem()
    {
        //get random data
        GameObject randomSpecialItem = specialItemsGmArray[Random.Range(0, specialItemsGmArray.Length)];
        Transform randomPosition = spawningLocationsArray[Random.Range(0, spawningLocationsArray.Length)];

        //spawn random special item
        GameObject spawnedSpecialItem = Instantiate(randomSpecialItem, randomPosition.position, randomSpecialItem.transform.rotation);
        spawnedSpecialItem.transform.SetParent(GameObject.FindGameObjectWithTag("special item parent").transform);

        /* mistake
        while(true){
            //ensure that there are an empty position
            int countOfSpawnedItem = GameObject.FindGameObjectsWithTag("points collecter item").Length
                + GameObject.FindGameObjectsWithTag("obstacle destroyer item").Length;

            if (countOfSpawnedItem >= spawningLocationsArray.Length)
            {
                //ther are not an empty position
                break;
            }
            else
            {
                //ther are an empty position
                while (true)
                {
                    //get random data
                    GameObject randomSpecialItem = specialItemsGmArray[Random.Range(0, specialItemsGmArray.Length)];
                    Transform randomPosition = spawningLocationsArray[Random.Range(0, spawningLocationsArray.Length)];
                    bool randomPositionIsEmpty = true;//intial value
                    //ensure that there are not another item based on <randomPosition>
                    foreach (GameObject Gm in GameObject.FindGameObjectsWithTag("points collecter item"))
                    {
                        if (Gm.transform.position == randomPosition.position)
                        {
                            randomPositionIsEmpty = false;
                        }
                    }
                    foreach (GameObject Gm in GameObject.FindGameObjectsWithTag("obstacle destroyer item"))
                    {
                        if (Gm.transform.position == randomPosition.position)
                        {
                            randomPositionIsEmpty = false;
                        }
                    }
                    if (randomPositionIsEmpty)
                    {
                        //spawn random special item
                        GameObject spawnedSpecialItem = Instantiate(randomSpecialItem, randomPosition.position, randomSpecialItem.transform.rotation);
                        spawnedSpecialItem.transform.SetParent(GameObject.FindGameObjectWithTag("special item parent").transform);

                        break;
                    }
                   
                }
               
            }
        }*/

    }
}
