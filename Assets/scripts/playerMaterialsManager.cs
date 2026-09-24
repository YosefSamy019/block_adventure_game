using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMaterialsManager : MonoBehaviour
{
    //array of player materials
    public Material[] playerMaterials;

    // Start is called before the first frame update
    void Start()
    {
        getRandomMaterial(true);
    }

    public void getRandomMaterial(bool allowRepeatedMaterial)
    {
        //allowRepeatedMaterial : this make the new material is different from the old , prevent repeating material

        if (allowRepeatedMaterial)
        {
            //put random material and ignore if this mew material is the old
            GetComponent<MeshRenderer>().material = playerMaterials[Random.Range(0, playerMaterials.Length)];
        }
        else
        {
            //put random material and ensure that the mew material is different from the old
            while (true)
            {
                //get random material
                Material randomMaterial = playerMaterials[Random.Range(0, playerMaterials.Length)];

                if (randomMaterial.name != GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", ""))
                {
                    //the mew material is different from the old

                    //apply random material 
                    GetComponent<MeshRenderer>().material = randomMaterial;

                    //break the loop
                    break;
                }
              
            }
           
        }

    }
}
