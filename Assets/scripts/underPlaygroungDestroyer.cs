using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class underPlaygroungDestroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Point")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
        }
    }
} 
