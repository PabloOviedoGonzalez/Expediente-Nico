using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayChess : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.ChangeScene("Chess");
    }
}
