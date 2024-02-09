using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class InteractableText : MonoBehaviour
{
    [SerializeField] private MonoBehaviour componentToActivate;
    public VideoPlayer videoPlayer;

    void Start()
    {
        // Asignar el evento cuando el video termine
        videoPlayer.loopPointReached += OnVideoFinished;

        if (componentToActivate != null)
        {
            componentToActivate.enabled = false;
        }
    }

    void Update()
    {
        // Verificar si el componente está activado y la tecla "E" ha sido presionada
        if (componentToActivate != null && componentToActivate.enabled && Input.GetKeyDown(KeyCode.E))
        {

            // Reproducir el video al inicio
            PlayVideo();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Comprobar si el objeto que entró en el trigger es el jugador (ajustar según tus necesidades)
        if (other.CompareTag("Player"))
        {
            // Activar el componente especificado en el inspector
            if (componentToActivate != null)
            {
                componentToActivate.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Comprobar si el objeto que salió del trigger es el jugador (ajustar según tus necesidades)
        if (other.CompareTag("Player"))
        {
            // Desactivar el componente especificado en el inspector
            if (componentToActivate != null)
            {
                componentToActivate.enabled = false;
            }
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // Cambiar a la siguiente escena cuando el video termine
        SceneManager.LoadScene("PCScene");
    }

    void PlayVideo()
    {
        // Iniciar la reproducción del video
        videoPlayer.Play();
    }
}

