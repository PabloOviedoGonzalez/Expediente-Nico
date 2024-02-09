using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class InteractableText : MonoBehaviour
{
    [SerializeField] private MonoBehaviour componentToActivate;
    public VideoPlayer videoPlayer;
    public RenderTexture renderTexture;

    // A�ade una referencia al script RawImageScript en el Inspector
    public RawImageScript rawImageScript;

    void Start()
    {
        // Asignar el evento cuando el video termine
        videoPlayer.loopPointReached += OnVideoFinished;

        if (componentToActivate != null)
        {
            componentToActivate.enabled = false;
        }

        if (rawImageScript == null)
        {
            Debug.LogError("No se ha asignado el script RawImageScript en el Inspector.");
        }
    }

    void Update()
    {
        // Verificar si el componente est� activado y la tecla "E" ha sido presionada
        if (componentToActivate != null && componentToActivate.enabled && Input.GetKeyDown(KeyCode.E))
        {
            // Reproducir el video al inicio
            PlayVideo();

            // Ejecutar el m�todo LoadVideoCanvas del script RawImageScript
            if (rawImageScript != null)
            {
                rawImageScript.LoadVideoCanvas();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Comprobar si el objeto que entr� en el trigger es el jugador (ajustar seg�n tus necesidades)
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
        // Comprobar si el objeto que sali� del trigger es el jugador (ajustar seg�n tus necesidades)
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
        // Iniciar la reproducci�n del video
        videoPlayer.Play();
    }
}
