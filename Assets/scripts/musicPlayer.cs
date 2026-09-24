using System.Collections;
using System.Collections.Generic;
//using System.Media;
using UnityEngine;

public class musicPlayer : MonoBehaviour
{
    //the sound played when player ram into point
    public AudioClip ramIntoPointAudio;

    //the sound played when player ram into obstacle
    public AudioClip ramIntoObstacleAudio;

    //the sound played when shootgun shoots a bullet
    public AudioClip shootgunShootsABulletAudio;

    //the sound played when player ram into a obstacle destroyer item (special item)
    public AudioClip ramIntoObstacleDestroyerItemAudio;

    //the sound played when player ram into a point collecter item (special item)
    public AudioClip ramIntoPointCollecterItemAudio;


    //you can play audios or no
    private bool canPlayAudios;

    private void Start()
    {
        if (PlayerPrefs.HasKey("audio is not mute"))
        {
            //set value
            canPlayAudios = bool.Parse(PlayerPrefs.GetString("audio is not mute"));
        }
        else
        {
            // put a value defaultly
            canPlayAudios = true;
        }
    }
    public void ramIntoPointAudioVoid(Vector3 position)
    {

        if (canPlayAudios)
        {
            AudioSource.PlayClipAtPoint(ramIntoPointAudio,position); 
        }
    }

    public void ramIntoObstacleAudioVoid(Vector3 position)
    {
        if (canPlayAudios)
        {
            AudioSource.PlayClipAtPoint(ramIntoObstacleAudio, position);
        }
    }
    public void shootgunShootsABulletAudioVoid(Vector3 position)
    {
        if (canPlayAudios)
        {
            AudioSource.PlayClipAtPoint(shootgunShootsABulletAudio, position);
        }
    }
    public void ramIntoObstacleDestroyerItemVoid(Vector3 position)
    {
        if (canPlayAudios)
        {
            AudioSource.PlayClipAtPoint(ramIntoObstacleDestroyerItemAudio, position);
        }
    }
    public void ramIntoPointCollecterItemVoid(Vector3 position)
    {
        if (canPlayAudios)
        {
            AudioSource.PlayClipAtPoint(ramIntoPointCollecterItemAudio, position);
        }
    }
}
