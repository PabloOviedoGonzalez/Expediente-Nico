using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class InteractableText : MonoBehaviour
{
    [SerializeField] private MonoBehaviour Textofcomputer;

    void Start()
    {
        if (Textofcomputer != null)
        {
            Textofcomputer.enabled = false;
        }
    }

    void Update()
    {
        // Verificar si el componente está activado y la tecla "E" ha sido presionada
        if (Textofcomputer != null && Textofcomputer.enabled && Input.GetKeyDown(KeyCode.E))
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Comprobar si el objeto que entró en el trigger es el jugador (ajustar según tus necesidades)
        if (other.CompareTag("Player"))
        {
            // Activar el componente especificado en el inspector
            if (Textofcomputer != null)
            {
                Textofcomputer.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Comprobar si el objeto que salió del trigger es el jugador (ajustar según tus necesidades)
        if (other.CompareTag("Player"))
        {
            // Desactivar el componente especificado en el inspector
            if (Textofcomputer != null)
            {
                Textofcomputer.enabled = false;
            }
        }
    }

}
