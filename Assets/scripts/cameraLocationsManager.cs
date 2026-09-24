using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class cameraLocationsManager : MonoBehaviour
{
    //xamera locations
    public Transform[] camLocatons;

    private void Start()
    {
        if (PlayerPrefs.HasKey("selected camera mode index in that array"))
        {
            //get old mode that user selected in the past and put it
            setNewLocation(PlayerPrefs.GetInt("selected camera mode index in that array"));
        }
        else
        {
            //set mode ranked 0 at default
            setNewLocation(0);
        }
       

    }

    public void changeCameraLcation(){

        //curent location index
        int currentLocationIndex = 0;

        //get index of curent location
        foreach (Transform t in camLocatons)
        {
            if (t.position == Camera.main.transform.position)
            {
                break;
            }
            currentLocationIndex++;
        }

        
        //set next location
        if (currentLocationIndex == camLocatons.Length-1)//player selected last location
        {
            setNewLocation(0);
        }
        else if (currentLocationIndex == 0)//player selected first location
        {
            setNewLocation(1);
        }
        else
        {
            setNewLocation(currentLocationIndex + 1);//set next location
        }

        //give a value to camera position.y to this var
        GameObject.FindGameObjectWithTag("Player").GetComponent<playerUiControls>().changeNativeCameraPositionY();
        //cameraNativePositionAxisY = Camera.main.transform.position.y;
    }

    //set a location to cam
    void setNewLocation(int locationIndex)
    {
        if (locationIndex<camLocatons.Length)//ensure locationIndex var is in array
        {
            Camera.main.transform.position = camLocatons[locationIndex].position;
            Camera.main.transform.rotation = camLocatons[locationIndex].rotation;

            //store new mode in player prefes
            PlayerPrefs.SetInt("selected camera mode index in that array",locationIndex);

        }
       
    }

}
