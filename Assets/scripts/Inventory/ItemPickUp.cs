using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que representa un objeto que el jugador puede recoger
public class ItemPickUp : Interactable
{
    // El objeto que se recoger� al interactuar
    public Item item;

    // M�todo llamado al interactuar con el objeto
    public override void Interact()
    {
        // Llama al m�todo Interact() de la clase base
        base.Interact();

        // Ejecuta la acci�n de recoger el objeto
        PickUp();
    }

    // M�todo para recoger el objeto
    void PickUp()
    {
        // Muestra un mensaje en la consola indicando que se est� recogiendo el objeto
        Debug.Log("Picking up" + item.name);

        // Intenta agregar el objeto al inventario, devuelve true si se recogi� con �xito
        bool wasPickedUp = Inventory1.instance.Add(item);

        // Si el objeto fue recogido con �xito, destruye el objeto en la escena
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
