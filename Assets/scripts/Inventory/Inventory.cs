using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public List<GameObject> Bag = new List<GameObject>();//almacena nuestros items
    public GameObject inv; //nuestro inventario
    public bool Activate_inv; //Activa y desactiva el inventario


    public GameObject Selector;
    public int ID; //indica el num de la casilla que estaremos seleccionando


    void OnTriggerEnter(Collider coll) //para detectar el contacto con el objeto
    {
        if (coll.CompareTag("Item"))
        {
            for(int i = 0; i < Bag.Count; i++)
            {
                if (Bag[i].GetComponent<Image>().enabled == false) //comprueba si algun objeto tiene su img desactivado
                {
                    Bag[i].GetComponent<Image>().enabled = true;//si es así, se activara
                    Bag[i].GetComponent<Image>().sprite = coll.GetComponent<Image>().sprite;//aparece la imagen
                    Bag[i].GetComponent<Slot>().itemName = coll.gameObject.name;
                    break; //para que no se repita hasta que volvamos a tocar el objeto
                }
            }
        }
    }

    public void Navegate()
    {
        if (Input.GetKeyDown(KeyCode.D)&& ID<Bag.Count - 1)
        {
            ID++; //Desplazamiento a la derecha
        }
        if (Input.GetKeyDown(KeyCode.A) && ID > 0)
        {
            ID--; //Desplazamiento izq
        }
        if (Input.GetKeyDown(KeyCode.W) && ID > 2)
        {
            ID-= 3; //subir
        }
        if (Input.GetKeyDown(KeyCode.S) && ID < 9)
        {
            ID+= 3 ; //baja
        }
        Selector.transform.position = Bag[ID].transform.position;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

  
    void Update()
    {
        Navegate();

        if (Activate_inv)
        {
            inv.SetActive(true); //se activa
        }
        else 
        { 
            inv.SetActive(false); 
        }  

        if (Input.GetKeyDown(KeyCode.Return)) //al presionar enter
        {
            Activate_inv = !Activate_inv; //se desactiva y activa con la misma tecla
        }
    }
}
