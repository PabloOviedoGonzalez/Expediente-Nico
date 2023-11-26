using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private PauseMenu pauseMenu;

    void Start()
    {
        // Obtener la referencia al script PauseMenu
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    void Update()
    { 
       
    }


   
    // M�todo para reanudar el juego
    public void ReanudarJuego()
    {
        if (pauseMenu != null)
        {
            pauseMenu.Resumed();
        }
    }

    // M�todo para reiniciar el juego
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }

    // M�todo para salir al men� principal
    public void exit()
    {
        // Cargar la escena del men� principal (puedes cambiar el n�mero seg�n tus necesidades)
        SceneManager.LoadScene("MainMenu");
        // Asegurarse de que el tiempo est� reanudado al ir al men� principal
        Time.timeScale = 1f;
    }
}
