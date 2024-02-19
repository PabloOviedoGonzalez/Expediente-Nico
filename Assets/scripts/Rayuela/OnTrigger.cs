using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
       // if (other.GetComponent<IdentificadorPelota>() && other.GetComponent<PlayerMovement>())
        //{
          Debug.Log("You Win");
        GameManager.instance.ChangeScene("Ajedrez");
        //}

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
