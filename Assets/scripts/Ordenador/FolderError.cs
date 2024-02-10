using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class FolderError : MonoBehaviour
{
    public Image imageError; // Variable para almacenar la imagen

    public void Start()
    {
        imageError.enabled = false;
    }

    // Método que se llamará al hacer clic en el primer botón para activar la imagen
    public void ActivateErrorImage()
    {
        if (imageError != null && !imageError.enabled)
        {
            imageError.enabled = true; // Activa la imagen en el inspector
        }
    }

    // Método que se llamará al hacer clic en el segundo botón para desactivar la imagen
    public void DesactivateErrorImage()
    {
        if (imageError != null)
        {
            imageError.enabled = false; // Desactiva la imagen en el inspector
        }
    }

    public void DoubleErrorImage()
    {
        if (imageError != null)
        {
            imageError.enabled = false; // Desactiva la imagen en el inspector
            Invoke("ActivateErrorImage", 0.1f);
        }
    }

    public void ErrorVideoNico()
    {

    }
}


