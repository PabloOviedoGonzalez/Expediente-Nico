using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CorrectPasword : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoToScene()
    {
        SceneManager.LoadScene("PCMainScene");
    }
}
