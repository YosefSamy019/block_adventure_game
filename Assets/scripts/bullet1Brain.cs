using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet1Brain : MonoBehaviour
{
    //target
    private GameObject targetGameobject;

    //bullet speed
    public float bulletSpeed;

    //bullet life
    public float bulletAge;

    // Start is called before the first frame update
    void Start()
    {
        //destroy bullet after ending age
        Destroy(this.gameObject,bulletAge);

        //find target with tag
        targetGameobject = GameObject.FindGameObjectWithTag("Player");

        //look at target
        transform.LookAt(targetGameobject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*bulletSpeed);
    }
}
