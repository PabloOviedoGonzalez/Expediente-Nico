using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // La referencia al padre que contendrá los slots del inventario en la interfaz gráfica.
    public Transform itemsParents;

    // Referencia al objeto de inventario.
    Inventory1 inventory;

    // Array que almacenará los slots del inventario.
    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        // Obtiene la instancia única del inventario.
        inventory = Inventory1.instance;

        // Suscribe el método UpdateUI al evento onItemChangedCallback del inventario.
        inventory.onItemChangedCallback += UpdateUI;

        // Obtiene todos los InventorySlot hijos del objeto itemsParents y los almacena en el array slots.
        slots = itemsParents.GetComponentsInChildren<InventorySlot>();
    }

    // Método que se llama cuando hay un cambio en el inventario para actualizar la interfaz gráfica.
    void UpdateUI()
    {
        // Itera a través de todos los slots en la interfaz gráfica.
        for (int i = 0; i < slots.Length; i++)
        {
            // Si hay un elemento en la posición i del inventario, agrega ese elemento al slot correspondiente.
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            // Si no hay un elemento en la posición i del inventario, limpia el slot correspondiente.
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
