using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class playerUiControls : MonoBehaviour
{
    //count Of  Point Ball that player crached into it
    int countOfRammedPointBall;

    //text ui of point Text
    public Text pointBallUI;

    //text ui of gameover Text
    public TextMeshProUGUI gameoverTextUI;

    //text ui of highscore Text
    public Text highScoreText;

    //move cam up gradually
    private bool moveCamUpGradually;

    //move cam down gradually
    private bool moveCamDownGradually;

    //native camera position.y
    private float cameraNativePositionAxisY;
    
    //count of clicking on replay btn
    private int countOfClickingOnReplBtn;

    /*//text ui of obstacle Text
    public Text obstacleUI;*/
    void Start()
    {
        //set value
        countOfClickingOnReplBtn = 0;


        //give a value to camera position.y to this var
        cameraNativePositionAxisY = Camera.main.transform.position.y;


        moveCamUpGradually   = false;
        moveCamDownGradually = false;

        //run game 
        Time.timeScale = 1;

        //disable game over txt when game begines
        gameoverTextUI.enabled = false;

        countOfRammedPointBall = 0;

        highScoreText.enabled = false;
    }

    void Update()
    {
        if (moveCamUpGradually)
        {
            //move camera up
            Camera.main.transform.position = new Vector3(
                Camera.main.transform.position.x,
                Camera.main.transform.position.y + 0.1f,
                Camera.main.transform.position.z);

            //make camera look at playGroung
            Camera.main.transform.LookAt(GameObject.FindGameObjectWithTag("PlayGround").transform.position);
        }


        if (moveCamDownGradually)
        {
            //speed of going down (v=d/t)
            //float d = Camera.main.transform.position.y - cameraNativePositionAxisY;
            //float speed = d / timeOfMoveCamDownGradually;
            /*fail
            Camera.main.transform.position = new Vector3(
                Camera.main.transform.position.x,
                Camera.main.transform.position.y -speed,
                Camera.main.transform.position.z);

            if (Camera.main.transform.position.y<cameraNativePositionAxisY)
            {
                Camera.main.transform.position = new Vector3(
                Camera.main.transform.position.x,
                cameraNativePositionAxisY,
                Camera.main.transform.position.z);
            }
            moveCamDownGradually = false;
            */


            //move camera down
            Camera.main.transform.position = new Vector3(
                Camera.main.transform.position.x,
                Camera.main.transform.position.y - 0.1f,
                Camera.main.transform.position.z);

            //make camera look at playGroung
            Camera.main.transform.LookAt(GameObject.FindGameObjectWithTag("PlayGround").transform.position);

            if (Camera.main.transform.position.y < cameraNativePositionAxisY)
            {
                Camera.main.transform.position = new Vector3(
                Camera.main.transform.position.x,
                cameraNativePositionAxisY,
                Camera.main.transform.position.z);
                moveCamDownGradually = false;

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }
    }

    //call this func when player ram into point ball
    public void pointBallUISetter()
    {
        countOfRammedPointBall++;

        //change text value on canvas
        pointBallUI.text = countOfRammedPointBall.ToString();

        //high score
        if (PlayerPrefs.HasKey("high score"))
        {
            //'+1' math operation is important 
            if (PlayerPrefs.GetInt("high score") + 1 >countOfRammedPointBall )
            {

            }
            else
            {
                highScoreText.enabled = true;
                PlayerPrefs.SetInt("high score", countOfRammedPointBall);

                /*old version
                //show toast
                GameObject.FindGameObjectWithTag("TM").GetComponent<toastManager>().showToast("high score", 1f);
                */
            }
        }
        else
        {
            PlayerPrefs.SetInt("high score",countOfRammedPointBall);

            //show high score
            highScoreText.enabled = true;
            PlayerPrefs.SetInt("high score", countOfRammedPointBall);
        }
    }

    //call this func when player ram into obstacle
    public void obstacleUISetter()
    {
        //stop shootgun location management
        GameObject shootgunLocationsManagerGo = GameObject.FindGameObjectWithTag("shootgun location");
        shootgunLocationsManagerGo.GetComponent<shootgunLocationsManager>().shootgunTurner(false);

        //stop shootgun shooting
        GameObject shootgunShootingGo = GameObject.FindGameObjectWithTag("shootgun1");
        shootgunLocationsManagerGo.GetComponent<shootgunLocationsManager>().shootgunTurner(false);

        //enable game over txt 
        gameoverTextUI.enabled = true;

        //give a value to camera position.y to this var
        cameraNativePositionAxisY = Camera.main.transform.position.y;

        //enable cam moving up
        moveCamUpGradually = true;

        //stop game 
        Time.timeScale = 0;

        //move player away
        GameObject.FindGameObjectWithTag("Player").transform.position=new Vector3(0,-100,0);


    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void replayGame()
    {
        countOfClickingOnReplBtn++;

        /* old version
         * SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
         */



        if (cameraNativePositionAxisY==Camera.main.transform.position.y)
        {
            //the game is not over 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else {
            if (countOfClickingOnReplBtn==1)
            {
                //stop moving camera up gradually
                moveCamUpGradually = false;
                moveCamDownGradually = true;

                //stop spwaning by destroy spawner gameobject components
                Destroy(GameObject.FindGameObjectWithTag("Spawner").GetComponent<pointsSpawner>());
                Destroy(GameObject.FindGameObjectWithTag("Spawner").GetComponent<obstaclesSpawner>());

                //show toast to make user know clicking again to restart now;
                GameObject.FindGameObjectWithTag("TM").GetComponent<toastManager>().showToast("click again to restart now", 10f);


                /*
                //Destroy all point 
                foreach (GameObject gm in GameObject.FindGameObjectsWithTag("Point"))
                {
                    Destroy(gm);
                }

                //Destroy all obstacles 
                foreach (GameObject gm in GameObject.FindGameObjectsWithTag("Obstacle"))
                {
                    Destroy(gm);
                }
                */
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    public void changeNativeCameraPositionY()
    {
        //give a value to camera position.y to this var
        cameraNativePositionAxisY = Camera.main.transform.position.y;
    }
}
