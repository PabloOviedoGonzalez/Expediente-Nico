using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAmbientMusic : MonoBehaviour
{
    //public AudioClip menuAmbientMusic;   //para poder asignar un AudioClip desde el inspector
    //[Range(0, 1)]
    //public float volumeMusic;   //para poder regular el volumen entre 0 y 1

    //// Start is called before the first frame update
    //void Start()
    //{
    //    AudioManager.instance.PlayAudioOnLoop(menuAmbientMusic, volumeMusic);  //llamamos al audiomanager y lo instanciamos
    //}

    public AudioClip menuAmbientMusic;   // Para poder asignar un AudioClip desde el inspector
    [Range(0, 1)]
    public float volumeMusic;   // Para regular el volumen entre 0 y 1

    private AudioSource audioSource;

    void Start()
    {
        // Si el AudioClip no está asignado, mostrar un error y salir del método
        if (menuAmbientMusic == null)
        {
            Debug.LogError("No se ha asignado ningún AudioClip al objeto actual.");
            return;
        }

        // Crear un AudioSource para reproducir el sonido
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = menuAmbientMusic;
        audioSource.volume = volumeMusic;
        audioSource.loop = true;  // Repetir el sonido en bucle

        // Reproducir el sonido
        audioSource.Play();
    }

    void OnDestroy()
    {
        // Detener la música al salir de la escena
        if (audioSource != null)
        {
            audioSource.Stop();
            Destroy(audioSource);
        }
    }

    void OnDisable()
    {
        // Detener la música al desactivar el script
        if (audioSource != null)
        {
            audioSource.Stop();
            Destroy(audioSource);
        }
    }
}


