using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleBrain : MonoBehaviour
{
    // obstacle life
    public float obstacleLife;

    //the GO that this obstacle will go towardes (player)
    private GameObject target;

    //obstacle speed towards player
    public float speed;

    // ensure this obstacle can move towards target
    private bool canWalk;

    //is this obstacle genius(can move towards target)
    private bool isGenius;
    // Start is called before the first frame update
    void Start()
    {
        //give isGenius a value from playerprefes
        if (PlayerPrefs.HasKey("genius obstacle") == true)
        {
            if (PlayerPrefs.GetString("genius obstacle") == "true")
            {
                isGenius = true;
            }
            else
            {
                isGenius = false;
            }
        }
        else
        {
            isGenius = true;
        }

        // this obstacle can not move towards target
        canWalk = false;

        // find player cube
        target = GameObject.FindGameObjectWithTag("Player");

        Invoke("hideObstacle", obstacleLife);
    }

    // Update is called once per frame
    void Update()
    {
        if (canWalk && isGenius)
        {
            transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
            transform.Translate( Vector3.forward*speed*Time.deltaTime);
        }
        
    }

    //call this func when obstacle die
    public void hideObstacle()
    {
        

        // destroy collider of obstacle
        Destroy(this.gameObject.GetComponent<CapsuleCollider>());

        //change tag to make spawner ignore this obstacle
        this.gameObject.tag = "Untagged";

       
        //destroy this obstacle 
        Destroy(this.gameObject,obstacleLife);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="PlayGround")
        {
            // this obstacle can move towards target
            canWalk = true;
        }
    }
}
