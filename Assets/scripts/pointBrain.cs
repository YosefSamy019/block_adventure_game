using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointBrain : MonoBehaviour
{
    //speed of rotation
    public float rotationSpeed;

    //move gradually to player position
    public bool moveToPlayerPosition;

    //player gameobject
    public GameObject playerGm;

    //speed of moving to the player that coin use it when the coin be moving to the player 
    public float speedOfMovingToThePlayer;

    // Start is called before the first frame update
    void Start()
    {
        //set a value
        moveToPlayerPosition = false;

        //find the player
        playerGm = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (moveToPlayerPosition)
        {
            ///the coin will move to player 
            
            //look at the player then move towards him
            transform.LookAt(new Vector3(playerGm.transform.position.x,playerGm.transform.position.y,playerGm.transform.position.z));
            transform.Translate(Vector3.forward * Time.deltaTime * speedOfMovingToThePlayer);
           
        }
       
        else
        {
            ///the coin will stand

            //rotation
            transform.Rotate(0, rotationSpeed, 0);
        }
        
    }

}
