using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Radio de interacción con el objeto
    public float radius = 3f;

    // Transform que determina la posición de interacción (puede ser diferente al transform del objeto)
    public Transform interactionTransform;

    // Variable que indica si el objeto está enfocado por el jugador
    bool isFocus = false;

    // Transform del jugador
    Transform player;

    // Variable que indica si ya se ha interactuado con el objeto
    bool hasInteracted = false;

    // Método virtual que se llama al interactuar con el objeto
    public virtual void Interact()
    {
        Debug.Log("Interact with " + transform.name);
    }

    // Método llamado en cada frame
    void Update()
    {
        // Si el objeto está enfocado y aún no se ha interactuado
        if (isFocus && !hasInteracted)
        {
            // Calcula la distancia entre el jugador y el objeto de interacción
            float distance = Vector3.Distance(player.position, interactionTransform.position);

            // Si la distancia es menor o igual al radio de interacción, realiza la interacción
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    // Método llamado cuando el objeto se enfoca
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    // Método llamado cuando el objeto deja de estar enfocado
    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    // Método que dibuja un gizmo en el editor para visualizar el radio de interacción
    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
