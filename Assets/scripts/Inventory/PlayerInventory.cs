using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInventory : MonoBehaviour
{
    public GameObject inventory;

    // Lista de scripts que se desactivarán cuando el inventario esté abierto
    public MonoBehaviour[] scriptsToDisable;

    // Lista de scripts que se activarán cuando el inventario esté cerrado
    public MonoBehaviour[] scriptsToEnable;

    // Start is called before the first frame update
    void Start()
    {
        if (inventory != null)
        {
            inventory.SetActive(false);
        }
    }

    // Método para activar o desactivar el inventario y los scripts correspondientes
    void ToggleInventoryState()
    {
        // Verifica si el inventario es nulo
        if (inventory == null)
        {
            Debug.LogError("No se ha asignado el GameObject de inventario en el Inspector.");
            return;
        }

        // Invierte el estado del inventario
        bool isInventoryActive = inventory.activeSelf;
        inventory.SetActive(!isInventoryActive);

        // Activa o desactiva los scripts correspondientes
        ToggleScripts(isInventoryActive ? scriptsToEnable : scriptsToDisable);
    }

    // Método para activar o desactivar scripts
    void ToggleScripts(MonoBehaviour[] scripts)
    {
        foreach (var script in scripts)
        {
            if (script != null)
            {
                script.enabled = !script.enabled;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Si se presiona la tecla "I"
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Invierte el estado del inventario y activa/desactiva los scripts correspondientes
            ToggleInventoryState();
        }

        // Verifica si el inventario está activo
        if (inventory != null && inventory.activeSelf)
        {
            // Bloquea el cursor y desactiva la visibilidad del cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // Desbloquea el cursor y activa la visibilidad del cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
    }
}
