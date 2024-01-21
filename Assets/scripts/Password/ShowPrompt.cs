using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPrompt : MonoBehaviour
{
    //The canvas that says "Press E to interact"
    public Canvas EPromptCanvas;
    //reference to password 
    public Password PuzzleScript;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Player is by the computer");
            //show e prompt canvas
            EPromptCanvas.enabled = true;
        }
    }

 
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player") //&& PuzzleScript.SecretCodeEntered == false)
        {
            Debug.Log("The player has left the computer");
            //hide E prompt canvas
            EPromptCanvas.enabled = false;
        }
    }
}
