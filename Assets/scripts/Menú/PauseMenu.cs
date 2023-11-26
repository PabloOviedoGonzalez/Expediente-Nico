using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool Gamepaused = false;
    // Start is called before the first frame update
    void Start()
    {
        // Comprueba que el juego no esté pausado al inicio
        Time.timeScale = 1f;
    }

    void Update()
    {
        // Verificar si se presiona la tecla Escape para pausar o reanudar el juego
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Gamepaused)
            {
                Resumed();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        Gamepaused = true;
        Time.timeScale = 0f; // Detener el tiempo para pausar el juego
    }

    public void Resumed()
    {
        Gamepaused = false;
        Time.timeScale = 1f; // Reanudar el tiempo
    }
}

