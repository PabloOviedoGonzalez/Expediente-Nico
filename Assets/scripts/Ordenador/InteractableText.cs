using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableText : MonoBehaviour
{
    [SerializeField] private MonoBehaviour componentToActivate;

    void Start()
    {
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
            // Cambiar a la escena especificada
            ChangeScene();
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

    private void ChangeScene()
    {
        // Cambiar a la escena especificada
        SceneManager.LoadScene("PCScene");
    }
}

