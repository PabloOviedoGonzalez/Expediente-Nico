using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    //Canvas
    public Canvas EPromptCanvas;
    public Canvas PuzzleCanvas;
    //Text
    public Text UserInputText;
    public string SecretCode = "Green";
    //Character
    public CharacterController PlayerController;
    //secret code is not entered
    public bool SecretCodeEntered = false;

    public void Update()
    {
        if(UserInputText.text == SecretCode && SecretCodeEntered == false)
        {
            Debug.Log("The secret code is correct!");
            SecretCodeEntered = true;
            EPromptCanvas.enabled = false;
            PuzzleCanvas.enabled = false;
            //Enable player movement
            PlayerController.enabled = true;
            //lock cursor
            Cursor.lockState = CursorLockMode.Locked;
        }



    }
    void OnTriggerStay(Collider col)
    {
        if(col.tag == "Player" && SecretCodeEntered ==false )
        {
            //confirma si presionan E
            if (Input.GetKey(KeyCode.E))
            {
                //show puzzle canvas
                PuzzleCanvas.enabled = true;
                //hide E prompt
                EPromptCanvas.enabled = false;
                //Stop the player movement
                PlayerController.enabled = false;
                //Give the player acces to cursor
                Cursor.lockState = CursorLockMode.None;
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                ExitButton();
            }
        }
    }
    public void ExitButton()
    {
        PuzzleCanvas.enabled = false;
        EPromptCanvas.enabled = true;
        //EnablePlayerMovement
        PlayerController.enabled = true;
        //Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }
}
