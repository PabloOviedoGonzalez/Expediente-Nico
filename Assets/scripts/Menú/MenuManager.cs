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


   
    // Método para reanudar el juego
    public void ReanudarJuego()
    {
        if (pauseMenu != null)
        {
            pauseMenu.Resumed();
        }
    }

    // Método para reiniciar el juego
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }

    // Método para salir al menú principal
    public void exit()
    {
        // Cargar la escena del menú principal (puedes cambiar el número según tus necesidades)
        SceneManager.LoadScene("MainMenu");
        // Asegurarse de que el tiempo esté reanudado al ir al menú principal
        Time.timeScale = 1f;
    }
}
