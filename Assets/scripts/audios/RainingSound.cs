using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainingSound : MonoBehaviour
{

    public AudioClip rainingSound;
    [Range(0, 1)]
    public float riningVolume;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayAudioOnLoop3D(rainingSound, transform.position, 0.5f, 4f , riningVolume);
    }

    
}
