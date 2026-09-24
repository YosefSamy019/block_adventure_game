using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGunShooterManagement : MonoBehaviour
{

    //bullet GO
    public GameObject bulletGameobject;

    //location of spawned bullet
    public Transform shootingLocation;

    //gun look at a target
    private GameObject targetGo;

    //time before every shooting
    public float loadTime;

    //turn on or off this gun
    private bool thisGunIsTurnedOn;

    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.HasKey("enable shootgun") == true)
        {
            //set state to this gun according to playerprefes
            thisGunIsTurnedOn = bool.Parse(PlayerPrefs.GetString("enable shootgun"));

            //enable or disable this shootgun
            this.gameObject.SetActive (bool.Parse(PlayerPrefs.GetString("enable shootgun")));
        }
        else
        {
            //enable this shootgun
            this.gameObject.SetActive(true);

            //playerprefs do not have the key so i will turn on it
            thisGunIsTurnedOn = true;
        }


        //find the target
        targetGo = GameObject.FindGameObjectWithTag("Player");

        InvokeRepeating("shootingFunction", loadTime, loadTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (thisGunIsTurnedOn)//ensure this gun is turned on
        {
            //look at the target
            transform.LookAt(targetGo.transform);
        }

    }

    void shootingFunction() { 
    
        if(thisGunIsTurnedOn){//ensure this gun is turned on

            //spawn bullet
            GameObject b = Instantiate(bulletGameobject, transform.position, Quaternion.Euler(0,0,0));

            //play audio
            GameObject.FindGameObjectWithTag("music manager").GetComponent<musicPlayer>().shootgunShootsABulletAudioVoid(transform.position);

        }
    }

    //this function turn shootgun on or off
    public void shootgunTurner(bool shootgunNewstate)
    {
        thisGunIsTurnedOn = shootgunNewstate;
    }
}
