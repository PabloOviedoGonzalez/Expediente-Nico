using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Shutdown : MonoBehaviour
{
    // Llama a este método para cambiar a la escena de la habitación del niño
    public void ChangeToChildRoomScene()
    {
        SceneManager.LoadScene("HabitaciónsNiño");
    }

    // Start is called before the first frame update
    void Start()
    {
        // Puedes realizar alguna configuración inicial si es necesario
    }

    // Update is called once per frame
    void Update()
    {
        // Puedes agregar código de actualización si es necesario
    }
}
