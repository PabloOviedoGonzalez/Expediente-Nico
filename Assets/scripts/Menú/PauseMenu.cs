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
                    // Si el PauseMenu está activo,
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                else
                {
                    // Si el PauseMenu no está activo
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
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
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Time.timeScale = 0f;
            pausemenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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
