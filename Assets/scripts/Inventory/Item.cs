using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Atributo para crear un nuevo objeto Item desde el menú de Unity
[CreateAssetMenu(fileName = "New Item", menuName = "Inventary/Item")]
public class Item : ScriptableObject
{
    // Nombre del objeto (puede ser modificado desde el Inspector de Unity)
    new public string name = "New Item";

    // Icono del objeto en el inventario (puede ser modificado desde el Inspector de Unity)
    public Sprite icon = null;

    // Indica si el objeto es predeterminado en el inventario (puede ser modificado desde el Inspector de Unity)
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        //Usar el item
        //Que pasa al usar el objeto

        Debug.Log("Using" + name);
    }

}

