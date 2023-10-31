using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float currentVel = 0;
    public float maxVel;
    public float acceleration;
    public float gravityForce = -9.81f; //fuerza de la gravedad para este obj
    public float jumpForce = 20f; //fuerza de salto
    private float playerYVelocity; //currentVelocidad en y del player
    private CharacterController controller;
    private Animator animator;
    private bool isSneaking = false;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if((x != 0 || z != 0) && currentVel < maxVel)
        {
            currentVel += acceleration * Time.deltaTime;
        }
        else if(x == 0 && z == 0)
        {
            currentVel = 0;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSneaking = true;
            currentVel = maxVel/2;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSneaking= false;
        }

        animator.SetFloat("vel", currentVel/maxVel);
        animator.SetBool("isSneaking", isSneaking);
        animator.SetBool("isGrounded", controller.isGrounded);


        Vector3 movementVector = transform.forward * currentVel * z + transform.right * currentVel * x + transform.up * gravityForce;

        playerYVelocity += gravityForce;

        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {
            animator.Play("jumpAnimation");
            playerYVelocity = jumpForce;
        }
        movementVector += transform.up * playerYVelocity;

        controller.Move(movementVector * Time.deltaTime);

    }
}

