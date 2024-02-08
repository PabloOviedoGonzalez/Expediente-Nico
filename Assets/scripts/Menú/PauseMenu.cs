using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausemenu;
    [SerializeField] private GameObject optionsmenu;

    private string currentSceneName;


    void Start()
    {
        // Obtener el nombre de la escena actual al inicio
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    public void Update()
    {
        // Comprobar si OptionsPanel está activo para evitar abrir el PauseMenu
        if (!optionsmenu.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Time.timeScale == 0f)
                {
                    // Si el PauseMenu está activo, ocultar el cursor
                    Cursor.lockState = CursorLockMode.Locked;
                }
                else
                {
                    // Si el PauseMenu no está activo, mostrar el cursor
                    Cursor.lockState = CursorLockMode.None;
                }

                TogglePauseMenu();
            }
        }
    }

    void TogglePauseMenu()
    {
        if (pausemenu.activeSelf)
        {
            Time.timeScale = 1f;
            pausemenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            pausemenu.SetActive(true);
        }
    }

    public void Reload()
    {
        Time.timeScale = 1f;
        pausemenu.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentSceneName);
        pausemenu.SetActive(false);
    }

    public void QuitMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
