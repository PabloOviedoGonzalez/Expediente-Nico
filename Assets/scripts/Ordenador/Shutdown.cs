using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Shutdown : MonoBehaviour
{
    // Llama a este m�todo para cambiar a la escena de la habitaci�n del ni�o
    public void ChangeToChildRoomScene()
    {
        SceneManager.LoadScene("Habitaci�nNi�o");
    }
}
