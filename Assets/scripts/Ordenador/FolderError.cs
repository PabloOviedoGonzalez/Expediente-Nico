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

    // M�todo que se llamar� al hacer clic en el primer bot�n para activar la imagen
    public void ActivateErrorImage()
    {
        if (imageError != null && !imageError.enabled)
        {
            imageError.enabled = true; // Activa la imagen en el inspector
        }
    }

    // M�todo que se llamar� al hacer clic en el segundo bot�n para desactivar la imagen
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


