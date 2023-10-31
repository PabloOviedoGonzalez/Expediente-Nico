using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceEcoSound : MonoBehaviour
{
    public AudioClip voiceEcoSound;
    [Range(0, 1)]
    public float voiceEcoVolume;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayAudio(voiceEcoSound, voiceEcoVolume);
    }

   
}
