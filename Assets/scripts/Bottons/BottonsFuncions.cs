using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BottonsFuncions : MonoBehaviour
{
    public void ChangeScene(string name)
    {
        GameManager.instance.ChangeScene(name);
        
    }


    public void exitGame(string name)
    {
        Application.Quit();
        Debug.Log("exit");
    }
}
