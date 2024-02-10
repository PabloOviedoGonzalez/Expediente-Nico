using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    public GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        if (inventory != null)
        {
            inventory.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Si se presiona la tecla "I"
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Invierte el estado del inventario (activa si est� desactivado, desactiva si est� activado)
            ToggleInventoryState();
        }
    }

    // M�todo para activar o desactivar el inventario
    void ToggleInventoryState()
    {
        // Verifica si el inventario es nulo
        if (inventory == null)
        {
            Debug.LogError("No se ha asignado el GameObject de inventario en el Inspector.");
            return;
        }

        // Invierte el estado del inventario y realiza la acci�n correspondiente
        inventory.SetActive(!inventory.activeSelf);
    }
}
