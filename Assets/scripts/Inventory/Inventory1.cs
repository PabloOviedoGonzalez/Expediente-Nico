using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory1 : MonoBehaviour
{
    // Instancia est�tica del inventario para seguir el patr�n Singleton
    public static Inventory1 instance;

    #region Singleton
    void Awake()
    {
        // Verifica si ya hay una instancia existente del inventario
        if (instance != null)
        {
            Debug.LogWarning("The are more than one instance of Inventory!");
            return;
        }
        // Si no hay instancia, establece esta como la instancia actual
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    // Espacio m�ximo en el inventario
    public int InventorySpace = 17;

    // Lista que almacena los elementos del inventario
    public List<Item> items = new List<Item>();

    // M�todo para agregar un elemento al inventario
    public bool Add(Item item)
    {
        // Verifica si el inventario est� lleno
        if (items.Count >= InventorySpace)
        {
            Debug.Log("Inventory Full");
            return false;
        }

        // Verifica si el elemento no es el predeterminado antes de agregarlo
        if (!item.isDefaultItem)
        {
            items.Add(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }

        return true;
    }

    internal void Remove(Item item)
    {
        throw new NotImplementedException();
    }

    // M�todo para eliminar un elemento del inventario
    /*
    public void Remove(Item item)
    {
        items.Remove(item);
    }
    */
}