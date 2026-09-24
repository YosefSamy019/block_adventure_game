using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class settingsManager : MonoBehaviour
{

    public Text geniusObstacleTxt;
    public Text spawnObstaclesTxt;
    public Text showBordersBtn;
    public Text enableShootGun;
    public Text clearHighScoreTxt;

    private void Start()
    {

        //do not pause the game
        Time.timeScale = 1;

        if (PlayerPrefs.HasKey("high score") == false)
        {
            PlayerPrefs.SetInt("high score", 0);
            clearHighScoreTxt.text = "clear high score\ncurrent high score is 0";
        }
        else
        {
            clearHighScoreTxt.text = "clear high score\ncurrent high score is "+PlayerPrefs.GetInt("high score").ToString();
        }

        if (PlayerPrefs.HasKey("genius obstacle") == false)
        {
            PlayerPrefs.SetString("genius obstacle", "true");
        }

        if (PlayerPrefs.HasKey("spawn obstacles") == false)
        {
            PlayerPrefs.SetString("spawn obstacles", "true");
        }
        if (PlayerPrefs.HasKey("show playground borders") == false)
        {
            PlayerPrefs.SetString("show playground borders", "true");
        }
        if (PlayerPrefs.HasKey("enable shootgun") == false)
        {
            PlayerPrefs.SetString("enable shootgun", "true");
        }


        //change btn texts to include trueor false
        geniusObstacleTxt.text += ": " + PlayerPrefs.GetString("genius obstacle");
        spawnObstaclesTxt.text += ": " + PlayerPrefs.GetString("spawn obstacles");
        showBordersBtn.text    += ": " + PlayerPrefs.GetString("show playground borders");
        enableShootGun.text    += ": " + PlayerPrefs.GetString("enable shootgun");
    }

    public void clearHighScore()
    {
        PlayerPrefs.DeleteKey("high score");
        clearHighScoreTxt.text = "deleting is done";
    }

    //make obstacles genius
    public void setGenuisObstacles()
    {
        if (PlayerPrefs.GetString("genius obstacle")=="true")
        {
            PlayerPrefs.SetString("genius obstacle", "false");
        }
        else
        {
            PlayerPrefs.SetString("genius obstacle", "true");
        }

        resetValuesintoBtns();

    }

    //spawn obstacles 
    public void spawnObstaclesOrNo()
    {
        if (PlayerPrefs.GetString("spawn obstacles") == "true")
        {
            PlayerPrefs.SetString("spawn obstacles", "false");
        }
        else
        {
            PlayerPrefs.SetString("spawn obstacles", "true");
        }

        resetValuesintoBtns();
    }

    //this function change true to false and false to true in btns textxs
    void resetValuesintoBtns()
    {
       
        //change btn texts to include true or false 
        geniusObstacleTxt.text = "genius obstacles: " + PlayerPrefs.GetString("genius obstacle");
        spawnObstaclesTxt.text = "spawn obstacles: "  + PlayerPrefs.GetString("spawn obstacles");
        showBordersBtn.text    = "show borders: "     + PlayerPrefs.GetString("show playground borders");
        enableShootGun.text    = "enable shootgun: "  + PlayerPrefs.GetString("enable shootgun");
    }

    //enable or disable shootgun
    public void enableShootgun()
    {

        if (PlayerPrefs.GetString("enable shootgun") == "true")
        {
            PlayerPrefs.SetString("enable shootgun", "false");
        }
        else
        {
            PlayerPrefs.SetString("enable shootgun", "true");
        }

        resetValuesintoBtns();
    }

    public void backToSartingMenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void showBorders()
    {
        if (PlayerPrefs.GetString("show playground borders") == "true")
        {
            PlayerPrefs.SetString("show playground borders", "false");
        }
        else
        {
            PlayerPrefs.SetString("show playground borders", "true");
        }

        resetValuesintoBtns();
    }


}
/*
 all playerprefes keys
-"high score"
set high score

-"genius obstacle"
make them genius or no

-"spawn obstacles"
soawn them or no

-"show playground borders"
enable or disable borders of playground in game scene 

-"enable shootgun"
enable shootgun during playing the scene

-"selected camera mode index in that array"
this key bring the mode that user selected in the past

-"audio is not mute"
this key tell you if you can play audios or no
 */
