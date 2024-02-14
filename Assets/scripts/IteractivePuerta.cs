using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IteractivePuerta : MonoBehaviour
{
    [SerializeField] private MonoBehaviour TextDoor;

    void Start()
    {

        if (TextDoor != null)
        {
            TextDoor.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Comprobar si el objeto que entr� en el trigger es el jugador (ajustar seg�n tus necesidades)
        if (other.CompareTag("Player"))
        {
            // Activar el componente especificado en el inspector
            if (TextDoor != null)
            {
                TextDoor.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Comprobar si el objeto que sali� del trigger es el jugador (ajustar seg�n tus necesidades)
        if (other.CompareTag("Player"))
        {
            // Desactivar el componente especificado en el inspector
            if (TextDoor != null)
            {
                TextDoor.enabled = false;
            }
        }
    }

    void Update()
    {
        // Verificar si el componente est� activado y la tecla "E" ha sido presionada
        if (TextDoor != null && TextDoor.enabled && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Habitaci�nNi�o");

        }
    }

}
