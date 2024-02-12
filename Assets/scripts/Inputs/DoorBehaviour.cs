//public class DoorBehaviour : MonoBehaviour
//{
//    Animator anim;
//    //Puedo abrir/ cerrar la puerta?
//    bool canOpenCloseDoor = false;
//    //La puerta puede ser abierta
//    bool doorCanOpen = true;
//    //Para conocer si la animación a terminado
//    bool animationFinish = true;
//    public bool puedoInteractuarConPuerta = false;


//    // Start is called before the first frame update
//    void Start()
//    {
//        anim = GetComponent<Animator>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (!puedoInteractuarConPuerta)
//            return;

//        if (Input.GetKeyDown(KeyCode.E) && canOpenCloseDoor && doorCanOpen && animationFinish)
//        {
//            anim.SetBool("canOpenCloseDoor", canOpenCloseDoor);
//            anim.SetBool("doorCanOpen", doorCanOpen);
//            animationFinish = false;
//            doorCanOpen = false;
//        }
//        else if (Input.GetKeyDown(KeyCode.E) && canOpenCloseDoor && !doorCanOpen && animationFinish)
//        {
//            anim.SetBool("canOpenCloseDoor", canOpenCloseDoor);
//            anim.SetBool("doorCanOpen", doorCanOpen);
//            animationFinish = false;
//            doorCanOpen = true;
//        }

//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        canOpenCloseDoor = true;
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        canOpenCloseDoor = false;
//    }

//    public void FinishAnimation()
//    {
//        animationFinish = true;
//    }
//}
