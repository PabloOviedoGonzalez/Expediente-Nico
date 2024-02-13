using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Rawimage2 : MonoBehaviour
{
    public RawImage canvasToActivate;  // Asigna el componente RawImage en el Inspector
    public VideoPlayer videoplayer;

    void Start()
    {
        // Suscribirse al evento de finalización del video
        videoplayer.loopPointReached += OnVideoEnd;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void LoadVideoCanvas()
    {
        // Verificar si se asignó un componente RawImage y VideoPlayer en el Inspector
        if (canvasToActivate != null && videoplayer != null)
        {
            // Activar el componente RawImage
            canvasToActivate.enabled = true;

            // Reproducir el video
            videoplayer.Play();
        }
        else
        {
            Debug.LogError("No se han asignado el componente RawImage o VideoPlayer en el Inspector.");
        }
    }

    // Método llamado cuando el video llega al final
    private void OnVideoEnd(VideoPlayer vp)
    {
        // Cambiar a la siguiente escena
        GameManager.instance.passChecked = true;
        FindObjectOfType<NoSe>().ToggleGOs(true);
        SceneManager.LoadScene("HabitaciónNiño");
    }
}
