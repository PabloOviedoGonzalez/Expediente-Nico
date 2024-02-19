using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSonido : MonoBehaviour
{
    public AudioClip audioClip;

    void Start()
    {
        // Asegúrate de que se haya asignado un AudioClip
        if (audioClip == null)
        {
            Debug.LogError("No se ha asignado ningún AudioClip al objeto actual.");
        }
    }

    void Update()
    {
        // Si se presiona el botón de mouse izquierdo o la pantalla táctil (en dispositivos móviles)
        if (Input.GetMouseButtonDown(0))
        {
            // Reproducir el AudioClip
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
        }
    }
}
