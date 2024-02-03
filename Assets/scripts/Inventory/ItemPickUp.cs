using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que representa un objeto que el jugador puede recoger
public class ItemPickUp : Interactable
{
    // El objeto que se recogerá al interactuar
    public Item item;

    // Método llamado al interactuar con el objeto
    public override void Interact()
    {
        // Llama al método Interact() de la clase base
        base.Interact();

        // Ejecuta la acción de recoger el objeto
        PickUp();
    }

    // Método para recoger el objeto
    void PickUp()
    {
        // Muestra un mensaje en la consola indicando que se está recogiendo el objeto
        Debug.Log("Picking up" + item.name);

        // Intenta agregar el objeto al inventario, devuelve true si se recogió con éxito
        bool wasPickedUp = Inventory1.instance.Add(item);

        // Si el objeto fue recogido con éxito, destruye el objeto en la escena
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
