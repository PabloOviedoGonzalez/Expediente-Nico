using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    // Referencia al objeto Image que mostrar� el icono del elemento en el slot.
    public Image icon;
    //public Button removeButton;

    // Objeto de tipo Item que representa el elemento en el slot.
    Item item;

    // M�todo que se llama para agregar un nuevo elemento al slot.
    public void AddItem(Item newItem)
    {
        // Asigna el nuevo elemento al slot.
        item = newItem;

        // Configura el sprite del icono con el sprite del elemento.
        icon.sprite = item.icon;

        // Hace visible el icono.
        icon.enabled = true;

        //removeButton.interactable = true;
    }

    // M�todo que se llama para limpiar el contenido del slot.
    public void ClearSlot()
    {
        // Elimina la referencia al elemento en el slot.
        item = null;

        // Elimina el sprite del icono y lo hace invisible.
        icon.sprite = null;
        icon.enabled = false;
        //removeButton.interactable = false;
    }
    /*public void OnRemoveButton()
    {
        // Llama al m�todo Remove del objeto de inventario para eliminar el elemento del inventario.
        Inventory1.instance.Remove(item);
    }
    */

    public void UseItem()
    {
        if(item!=null)
        {
            item.Use();
        }
    }
    
}
