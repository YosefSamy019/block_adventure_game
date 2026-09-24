using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class timeManagerScript : MonoBehaviour
{
    //time text
    public Text timeTxt;
    // Update is called once per frame
    void Update()
    {

        timeTxt.text ="Time:\n"+ ((int) Time.timeSinceLevelLoad).ToString();
    }
}
