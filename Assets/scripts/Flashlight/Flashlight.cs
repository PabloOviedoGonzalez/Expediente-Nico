using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light lightFlashlight;
    public bool activLight;
    public bool flashlightInHand;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && flashlightInHand == true)
        {
            activLight = !activLight;

            if (activLight == true)
            {
                lightFlashlight.enabled = true; //enciende
            }

            if (activLight == false)
            {
                lightFlashlight.enabled = false; //desactiva
            }
        }

    }
}

