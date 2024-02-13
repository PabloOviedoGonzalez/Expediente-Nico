using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayuelaBall : MonoBehaviour
{
    public float force;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            gameObject.GetComponent<Rigidbody>().AddForce(force * collision.transform.forward, ForceMode.Impulse);
        }
    }
}
