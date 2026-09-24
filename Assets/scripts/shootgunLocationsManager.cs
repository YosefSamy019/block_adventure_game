using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootgunLocationsManager : MonoBehaviour
{

    //shootgun locations in the scene
    public Transform[] shootgunLocations;

    //change current locations after inputed time
    public float changingTime;

    //shootGun gameobject
    private GameObject shootgunGameobject;

    //turn on this gun
    private bool thisGunIsTurnedOn;

    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.HasKey("enable shootgun") == true)
        {
            //set state to this gun according to playerprefes
            thisGunIsTurnedOn = bool.Parse(PlayerPrefs.GetString("enable shootgun"));
        }
        else
        {
            //playerprefs do not have the key so i will turn on it
            thisGunIsTurnedOn = true;
        }
        

        //find the shootgun
        shootgunGameobject = GameObject.FindGameObjectWithTag("shootgun1");

        InvokeRepeating("changer",changingTime,changingTime);



        //change the location of the shootgun in the start of the game;
        changer();
    }


    //this function change the locations
    void changer()
    {
        if (thisGunIsTurnedOn)//shootgun is turned on
        {
            //get random location
            Transform nextLocation = shootgunLocations[Random.Range(0,shootgunLocations.Length)];

            //chang current location to the new
            shootgunGameobject.transform.position = nextLocation.position;
        }
        
    }

    //this function turn shootgun on or off
    public void shootgunTurner(bool shootgunNewstate)
    {
        thisGunIsTurnedOn = shootgunNewstate;
    }
}
