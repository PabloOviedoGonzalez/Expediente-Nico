using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWithPass : MonoBehaviour
{
    public bool activateIfPassChecked;

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(GameManager.instance.passChecked == activateIfPassChecked);
    }
}
