using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playgroundBorderManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("show playground borders"))
        {
            //enable or disable borders according to <PlayerPrefs.HasKey("show playground borders")> value
            bool visionValue = bool.Parse(PlayerPrefs.GetString("show playground borders"));
            foreach (GameObject gm in GameObject.FindGameObjectsWithTag("Playground Border"))
            {
                gm.SetActive(visionValue);
            }
        }
        else
        {
            foreach (GameObject gm in GameObject.FindGameObjectsWithTag("Playground Border"))
            {
                gm.SetActive(true);
            }
        }
        //i do not need this component so i will destoy it
        Destroy(this.gameObject.GetComponent<playgroundBorderManager>());
    }

   
}
