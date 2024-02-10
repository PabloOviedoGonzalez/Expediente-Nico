using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void CambiarAEscenaPC()
    {
        // Cambia a la escena "PCScene" al hacer clic en el botón
        SceneManager.LoadScene("PCScene");
    }
}
