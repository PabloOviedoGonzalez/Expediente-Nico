using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickFlashlight : MonoBehaviour
{
    public GameObject flashlight;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            flashlight.SetActive(true);
            flashlight.GetComponent<Flashlight>().flashlightInHand = true;
            Destroy(gameObject);
        }
    }
}
