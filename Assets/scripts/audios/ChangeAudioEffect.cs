using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudioEffect : MonoBehaviour
{
    public AudioClip StepClip;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("hola");
            player.GetComponent<AudioSource>().clip = StepClip;
        }
    }
   
}