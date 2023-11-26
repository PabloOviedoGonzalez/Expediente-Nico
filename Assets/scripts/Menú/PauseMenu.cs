using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //[SerializeField] private GameObject botonpausa;
    [SerializeField] private GameObject pausemenu;

    public void Update()
    {
        Cursor.lockState = CursorLockMode.None; // Bloquear el cursor del mouse.

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pausemenu.SetActive(true);
        }
    }
    public void reanudar()
    {
        Time.timeScale = 1f;
        pausemenu.SetActive(false);
    }

    public void reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("HabitaciónNiño");
    }

    public void Salir()
    {
        SceneManager.LoadScene("MainMenu");
    }
}