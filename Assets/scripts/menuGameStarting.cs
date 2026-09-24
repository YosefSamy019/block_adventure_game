using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuGameStarting : MonoBehaviour
{
    //the text shown in audio btn
    public UnityEngine.UI.Text audioBtnText;

    private void Start()
    {
        //do not pause the game
        Time.timeScale = 1;

        if (PlayerPrefs.HasKey("audio is not mute") == false)
        {
            PlayerPrefs.SetString("audio is not mute", "true");

            //show audio is not muted
            audioBtnText.text = "Audio: true";
        }
        else
        {
            //show audio is muted or false
            audioBtnText.text = "Audio: "+ PlayerPrefs.GetString("audio is not mute");
        }
    }
    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void settings()
    {
        SceneManager.LoadScene("settings");
    }
    public void muteAudioBtn()
    {
        //change play audio or no
        if (PlayerPrefs.HasKey("audio is not mute"))
        {
            if (PlayerPrefs.GetString("audio is not mute")=="true")
            {
                PlayerPrefs.SetString("audio is not mute", "false");
            }
            else
            {
                PlayerPrefs.SetString("audio is not mute", "true");
            }

        }
        /* old version
        //show toast including new value
        GameObject.FindGameObjectWithTag("TM").GetComponent<toastManager>().showToast(
            "now: "+PlayerPrefs.GetString("audio is not mute"),
            2f);
        */

        //show audio is muted or false
        audioBtnText.text = "Audio: " + PlayerPrefs.GetString("audio is not mute");

    }
}




