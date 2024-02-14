using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PasswordCheck : MonoBehaviour
{
    public TMP_InputField passwordInputField;
    public GameObject errorImage;

    void Start()
    {
        // Asegúrate de que la imagen de error esté desactivada al inicio
        errorImage.SetActive(false);
    }

    public void CheckPassword()
    {
        // Comprueba si el texto del InputField es igual a "Nico1"
        if (passwordInputField.text == "Jake")
        {
            // Cambia a la escena "PCMainScene" si la contraseña es correcta
            SceneManager.LoadScene("Pcdesktop");
        }
        else
        {
            // Muestra la imagen de error si la contraseña es incorrecta
            errorImage.SetActive(true);
        }
    }

    public void DesactivateImage()
    {
        errorImage.SetActive(false);
    }
    public void DesactivateDoubleErrorImage()
    {
        if (errorImage != null)
        {
            errorImage.SetActive(false); // Desactiva la imagen en el inspector
            Invoke("CheckPassword", 0.1f);
        }
    }
}


