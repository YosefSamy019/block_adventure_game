using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTriggerFunction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle destroyer item")
        {
            //play audio
            GameObject.FindGameObjectWithTag("music manager").GetComponent<musicPlayer>().ramIntoObstacleDestroyerItemVoid(other.transform.position);

            ///player rammed into a special item that destroy all obstacles
            //find all obstacle and destroy them
            foreach (GameObject gm in GameObject.FindGameObjectsWithTag("Obstacle"))
            {
                gm.GetComponent<obstacleBrain>().hideObstacle();
            }

            //destroy the special item
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "points collecter item")
        {
            //play audio
            GameObject.FindGameObjectWithTag("music manager").GetComponent<musicPlayer>().ramIntoPointCollecterItemVoid(other.transform.position);

            ///player rammed into a special item that makes all points move towards the player
            //find all obstacle and destroy them
            foreach (GameObject gm in GameObject.FindGameObjectsWithTag("Point"))
            {
                //destroy rigidbody of coin
                Destroy(gm.GetComponent<Rigidbody>());

                //make the point isTrigger
                gm.GetComponent<BoxCollider>().isTrigger = true;

                //make the point move towards the player
                gm.GetComponent<pointBrain>().moveToPlayerPosition = true;

            }

            //destroy the special item
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Point")
        {

            /*the point gameobject.isTrigger equal true or false so i shoud repeat this code of collision in the <playerTriggerFunction> class
             * 
             */
            Destroy(other.gameObject);

            //add 1 to the score
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerCollisionFunction>().countOfDestroedPoint++;

            //get platerUiControl script && call pointBallUISetter function
            GetComponent<playerUiControls>().pointBallUISetter();

            //play audio
            GameObject.FindGameObjectWithTag("music manager").GetComponent<musicPlayer>().ramIntoPointAudioVoid(other.transform.position);


            //show toast
            //GameObject.FindGameObjectWithTag("TM").GetComponent<toastManager>().showToast("point",0.5f);

        }
    }
}
