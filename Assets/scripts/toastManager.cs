using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class toastManager : MonoBehaviour
{
    //Toast UI Text
    public Text toastTxt;
    // Start is called before the first frame update
    void Start()
    {
        toastTxt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showToast(string msg,float stayingTime)
    {
        toastTxt.enabled = true;
        toastTxt.text = msg;
        Invoke("hideTextAfterTime",stayingTime);
    }
    void hideTextAfterTime()
    {

        toastTxt.enabled = false;
        //toastTxt.GetComponent<Text>().color = new Color(0,0,0,Mathf.Lerp(255,0,0.5f));
        
    }
}
