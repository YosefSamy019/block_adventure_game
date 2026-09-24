using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class joystickManager : MonoBehaviour
{
    public Image joyStickHandle;
    public bool isDrag;
    public GameObject playerGo;
    private Rigidbody playerRb;
    public float playerSpeedDuringTouch; 
    // Start is called before the first frame update
    void Start()
    {
        isDrag = false;
        playerRb = playerGo.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount>0)
        {
            touchsAndMouses();
        }
        if (Input.GetMouseButton(0))
        {
            isDrag = true;
        }
        else
        {
            isDrag = false;
        }

        if (isDrag)
        {
            touchsAndMouses();
        }
    }
    void touchsAndMouses()
    {

        //print(joyStickHandle.rectTransform.localPosition.x);
        /*playerRb.velocity = new Vector3(
            joyStickHandle.rectTransform.localPosition.x*100,
            playerRb.velocity.y, 
            joyStickHandle.rectTransform.localPosition.y*100
            );*/

        if (joyStickHandle.rectTransform.localPosition.x!=0)
        {
            int dir = (int)(joyStickHandle.rectTransform.localPosition.x/Mathf.Abs(joyStickHandle.rectTransform.localPosition.x));
            playerGo.transform.position = new Vector3(
            playerGo.transform.position.x + (playerSpeedDuringTouch*dir),
            playerGo.transform.position.y,
            playerGo.transform.position.z
            );
        }
        if (joyStickHandle.rectTransform.localPosition.y != 0)
        {
            int dir = (int)(joyStickHandle.rectTransform.localPosition.y / Mathf.Abs(joyStickHandle.rectTransform.localPosition.y));
            playerGo.transform.position = new Vector3(
            playerGo.transform.position.x ,
            playerGo.transform.position.y,
            playerGo.transform.position.z + (playerSpeedDuringTouch * dir)
            );
        }

        /*playerGo.transform.position = new Vector3(
            playerGo.transform.position.x+ (joyStickHandle.rectTransform.localPosition.x/Time.fixedTime), 
            playerGo.transform.position.y,
            playerGo.transform.position.z+ (joyStickHandle.rectTransform.localPosition.y/Time.fixedTime)
            );*/
    }
    
}
