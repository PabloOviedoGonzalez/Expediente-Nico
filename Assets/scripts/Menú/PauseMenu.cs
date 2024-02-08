using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausemenu;

    private string currentSceneName;

    public static PauseMenu instance;

    void Start()
    {
        // Obtener el nombre de la escena actual al inicio
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    void Awake() // se hace en el awake para q se inicialice lo primero, por si en el start hubiera algo q lo use y lo usase antes de q se iniciase
    {
        if (instance == null)//comprueba si instance no contiene informacion. tambien hace q no se destruya nunca
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //si tiene info, significa q ya existe otro GameManager y destruye este para q no se duplique ya q solo puede haber uno
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        //Si el pausemenu esta abierto que salaga el cursor del mouse sino lo esta desaparezca
        //Si OptionsPanel esta activo, no se abara el pause menu al darle al escape sino que vuelva atras
        Cursor.lockState = CursorLockMode.None; // Bloquear el cursor del mouse.

        if (Input.GetKeyDown(KeyCode.Escape))
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
        //que al reiniciar me cierre el menu
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentSceneName);
    }

    public void QuitMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}