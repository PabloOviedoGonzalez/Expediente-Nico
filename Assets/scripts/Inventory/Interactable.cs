using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;
    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;

    [SerializeField] private GameObject TextObject;

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);

            if (distance <= radius)
            {
                // Activa el TextObject cuando el jugador está en el radio de interacción
                if (TextObject != null)
                {
                    TextObject.SetActive(true);
                }
            }
            if (distance <= radius && Input.GetKeyDown(KeyCode.E))
            {
                Interact();
                hasInteracted = true;

                // Desactiva el TextObject cuando el jugador deja de estar en el radio de interacción
                if (TextObject != null)
                {
                    TextObject.SetActive(false);
                }
            }

            if (distance > radius)
            {
                // Desactiva el TextObject cuando el jugador deja de estar en el radio de interacción
                if (TextObject != null)
                {
                    TextObject.SetActive(false);
                }
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

    public virtual void Interact()
    {
        Debug.Log("Interact with " + transform.name);
    }
}
