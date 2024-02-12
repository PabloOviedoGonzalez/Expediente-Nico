using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RawImageScript : MonoBehaviour
{
    public RawImage canvasToActivate;  // Asigna el componente Canvas en el Inspector
    public VideoPlayer videoplayer;

    void Start()
    {
        // Puedes realizar alguna configuración inicial si es necesario
    }

    public void LoadVideoCanvas()
    {
        // Verificar si se asignó un componente Canvas en el Inspector
        if (canvasToActivate != null)
        {
            // Activar el componente Canvas
            canvasToActivate.enabled = true;
            videoplayer.enabled = true;
        }
        else
        {
            Debug.LogError("No se ha asignado el componente Canvas en el Inspector.");
        }
    }
}

