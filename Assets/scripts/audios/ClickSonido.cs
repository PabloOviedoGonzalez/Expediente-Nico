using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSonido : MonoBehaviour
{
    public AudioClip audioClip;

    void Start()
    {
        // Aseg�rate de que se haya asignado un AudioClip
        if (audioClip == null)
        {
            Debug.LogError("No se ha asignado ning�n AudioClip al objeto actual.");
        }
    }

    void Update()
    {
        // Si se presiona el bot�n de mouse izquierdo o la pantalla t�ctil (en dispositivos m�viles)
        if (Input.GetMouseButtonDown(0))
        {
            // Reproducir el AudioClip
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
        }
    }
}
