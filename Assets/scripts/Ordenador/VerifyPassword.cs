using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VerifyPassword : MonoBehaviour
{
    private InputField inputTextField;

    public void CheckPasswordAndLoadScene()
    {
        switch (inputTextField.text)
        {
            case "Nico1":
                SceneManager.LoadScene("PCMainScene");
                break;

            default:
                inputTextField.text = "";
                break;
        }
    }

}