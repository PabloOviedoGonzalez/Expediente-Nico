using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BottonsFuncions : MonoBehaviour
{
    public void ChangeScene(string PasilloMorgue)
    {
        GameManager.instance.ChangeScene(PasilloMorgue);
        
    }


    public void exitGame(string name)
    {
        Application.Quit();
        Debug.Log("exit");
    }
}
