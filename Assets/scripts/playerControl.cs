using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    //this is speed of player
    public int speed;

   
    //rigidbody of player
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //get rigidbody of player cube
        rb=GetComponent<Rigidbody>();

       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector3(speed,rb.velocity.y,rb.velocity.z);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y,speed);

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speed);

        }
        else
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);

        }

        

        //ensure player above playground block
        if (transform.position.y<-5)
        {
            GetComponent<playerUiControls>().obstacleUISetter();
        }
    }
}
