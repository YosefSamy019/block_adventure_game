using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollisionFunction : MonoBehaviour
{
    public int countOfDestroedPoint;

   

    private void Start()
    {
        countOfDestroedPoint = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Point")
        {

            /*the point gameobject.isTrigger equal true or false so i shoud repeat this code of collision in the <playerTriggerFunction> class
             * 
             */
           
            Destroy(collision.gameObject);
            
            countOfDestroedPoint++;

            //get platerUiControl script && call pointBallUISetter function
            GetComponent<playerUiControls>().pointBallUISetter();

            //play audio
            GameObject.FindGameObjectWithTag("music manager").GetComponent<musicPlayer>().ramIntoPointAudioVoid(collision.transform.position);


            //show toast
            //GameObject.FindGameObjectWithTag("TM").GetComponent<toastManager>().showToast("point",0.5f);

        }

        else if(collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "bullet 1")
        {

           
            //play audio
            GameObject.FindGameObjectWithTag("music manager").GetComponent<musicPlayer>().ramIntoObstacleAudioVoid(collision.transform.position);

            //get platerUiControl script && call obstacleUISetter function
            GetComponent<playerUiControls>().obstacleUISetter();


        }

        

    }
    
}

