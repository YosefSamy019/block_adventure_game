using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playerHidderItemBrain : MonoBehaviour
{
    //player gameObject
    private GameObject playerGm;

    //duration of hidding
    public float durationOfHidding;

    public Material blackMaterial;

    public Material oldMaterial; 

    // Start is called before the first frame update
    void Start()
    {
        //find the player
        playerGm = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hidePlayer();
            Invoke("showPlayer",durationOfHidding);
            GetComponent<BoxCollider>().enabled = false;
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        }
    }

    //this function make the player hiddef
    void hidePlayer()
    {
        oldMaterial = playerGm.GetComponent<MeshRenderer>().material;
        playerGm.GetComponent<Rigidbody>().useGravity = false;
        playerGm.GetComponent<BoxCollider>().enabled = false;
        playerGm.GetComponent<MeshRenderer>().material = blackMaterial;
    }

    //this function make the player shown

    void showPlayer()
    {
        playerGm.GetComponent<Rigidbody>().useGravity = true;
        playerGm.GetComponent<BoxCollider>().enabled = true;
        playerGm.GetComponent<MeshRenderer>().material = oldMaterial;

        Destroy(this.gameObject);
    }
}
