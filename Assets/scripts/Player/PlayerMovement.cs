using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float currentVel = 0;
    public float maxVel;
    public float acceleration;
    public float gravityForce = -9.81f; // Fuerza de la gravedad para este objeto
    public float jumpForce = 20f; // Fuerza de salto
    private float playerYVelocity; // Velocidad actual en y del jugador
    private CharacterController controller;
    private Animator animator;
    private bool isSneaking = false;

    // Objeto interactuable actualmente enfocado
    private Interactable focus;

    //pasos 
    public AudioSource steps;
    private bool Vactive; //vertical activo
    private bool Hactive; //horizontal activo

    // Start se llama antes del primer frame
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Obtener entrada del teclado
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Ajustar la velocidad actual según la entrada y aceleración
        if ((x != 0 || z != 0) && currentVel < maxVel)
        {
            currentVel += acceleration * Time.deltaTime;
        }
        else if (x == 0 && z == 0)
        {
            currentVel = 0;
        }

        // Verificar si el jugador está agachándose
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSneaking = true;
            currentVel = maxVel / 2;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSneaking = false;
        }

        // Actualizar parámetros del Animator
        animator.SetFloat("vel", currentVel / maxVel);
        animator.SetBool("isSneaking", isSneaking);
        animator.SetBool("isGrounded", controller.isGrounded);

        // Calcular el vector de movimiento
        Vector3 movementVector = transform.forward * currentVel * z + transform.right * currentVel * x + transform.up * gravityForce;

        // Aplicar la gravedad
        playerYVelocity += gravityForce;

        // Verificar si el jugador está en el suelo y presiona la tecla de salto
        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {
            animator.Play("jumpAnimation");
            playerYVelocity = jumpForce;
        }

        // Ajustar el vector de movimiento con la velocidad en y
        movementVector += transform.up * playerYVelocity;

        // Mover el controlador de personaje
        controller.Move(movementVector * Time.deltaTime);


        //sonidos pasos
        if (Input.GetButtonDown("Horizontal"))
        {
            if (Vactive == false)
            {
                Hactive = true;
                steps.Play();
            }
        }
        if (Input.GetButtonDown("Vertical"))
        {
            if (Hactive == false)
            {
                Vactive = true;
                steps.Play();
            }
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            Hactive = false;
            if (Vactive == false) //tampoco se tienen que estar presionando las verticales
            {
                steps.Pause();
            }

        }
        if (Input.GetButtonUp("Vertical"))
        {
            Vactive = false;
            if (Hactive == false) //tampoco se tienen que estar presionando las horizontales
            {
                steps.Pause();
            }
        }
            
            // Lanzar un rayo hacia adelante desde la cámara para interactuar con objetos
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            // Obtener el componente Interactable del objeto golpeado
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                // Establecer el objeto como enfoque
                SetFocus(interactable);
            }
        }
    }

    // Método para establecer el objeto actualmente enfocado
    void SetFocus(Interactable newFocus)
    {
        // Si ya hay un objeto enfocado, dejar de enfocarlo
        if (focus != null)
        {
            focus.OnDefocused();
        }

        // Establecer el nuevo objeto como enfoque
        focus = newFocus;
        newFocus.OnFocused(transform);
    }
}

