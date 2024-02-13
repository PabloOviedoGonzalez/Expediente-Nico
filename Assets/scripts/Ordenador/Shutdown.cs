using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Shutdown : MonoBehaviour
{
    // Llama a este método para cambiar a la escena de la habitación del niño
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ChangeToChildRoomScene()
    {
        FindObjectOfType<NoSe>().ToggleGOs(true);
        SceneManager.LoadScene("HabitaciónNiño");
    }
}
