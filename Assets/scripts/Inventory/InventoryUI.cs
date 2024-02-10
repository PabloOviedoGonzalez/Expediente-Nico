using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // La referencia al padre que contendr� los slots del inventario en la interfaz gr�fica.
    public Transform itemsParents;

    // Referencia al objeto de inventario.
    Inventory1 inventory;

    // Array que almacenar� los slots del inventario.
    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        // Obtiene la instancia �nica del inventario.
        inventory = Inventory1.instance;

        // Suscribe el m�todo UpdateUI al evento onItemChangedCallback del inventario.
        inventory.onItemChangedCallback += UpdateUI;

        // Obtiene todos los InventorySlot hijos del objeto itemsParents y los almacena en el array slots.
        slots = itemsParents.GetComponentsInChildren<InventorySlot>();
    }

    // M�todo que se llama cuando hay un cambio en el inventario para actualizar la interfaz gr�fica.
    void UpdateUI()
    {
        // Itera a trav�s de todos los slots en la interfaz gr�fica.
        for (int i = 0; i < slots.Length; i++)
        {
            // Si hay un elemento en la posici�n i del inventario, agrega ese elemento al slot correspondiente.
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            // Si no hay un elemento en la posici�n i del inventario, limpia el slot correspondiente.
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
