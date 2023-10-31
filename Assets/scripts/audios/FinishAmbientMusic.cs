using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishAmbientMusic : MonoBehaviour
{
    public AudioClip finishAmbientMusic;   //para poder asignar un AudioClip desde el inspector
    [Range(0, 1)]
    public float volumeMusic;   //para poder regular el volumen entre 0 y 1

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayAudioOnLoop(finishAmbientMusic, volumeMusic);  //llamamos al audiomanager y lo instanciamos
    }
}
