using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Shutdown : MonoBehaviour
{
    // Llama a este m�todo para cambiar a la escena de la habitaci�n del ni�o
    public void ChangeToChildRoomScene()
    {
        SceneManager.LoadScene("Habitaci�nsNi�o");
    }

    // Start is called before the first frame update
    void Start()
    {
        // Puedes realizar alguna configuraci�n inicial si es necesario
    }

    // Update is called once per frame
    void Update()
    {
        // Puedes agregar c�digo de actualizaci�n si es necesario
    }
}
