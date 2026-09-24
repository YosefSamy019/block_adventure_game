using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointCollecterItemBrain : MonoBehaviour
{
    //the age that gameobject spend before destroying it
    public float gmLife;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyThisGameObject", gmLife);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //this function destroy this gm
    private void destroyThisGameObject()
    {
        Destroy(this.gameObject);
    }
}
