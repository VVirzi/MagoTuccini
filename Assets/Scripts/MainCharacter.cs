using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public static MainCharacter Instance;
    [SerializeField] public int speedX;
    public float speedY = 300;

    public int initialSpeedX;
    //Llamo al script del groundcheck
    private GroundCheck check;
    
    
    Component Transform;
    
    //Animacion
    Animator anim;
    //Fuerzas
    Rigidbody2D rb;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        //Obtengo el componenete Animator y Rigidbody2D del objeto
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        check = GetComponent<GroundCheck>();
        initialSpeedX = speedX;
    }

    // Update is called once per frame
        void Update()
    {
        //Inputs y linea de movimiento
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(1, 0, 0) * (speedX * Time.deltaTime));
            transform.eulerAngles = new Vector3(0, 180, 0) ;
            Debug.Log("Izq");
        }
        

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(1, 0, 0) * (speedX * Time.deltaTime));
            transform.eulerAngles = new Vector3(0, 0, 0);
            Debug.Log("Der");
        }
        

        if (Input.GetKeyDown(KeyCode.Space) && check.grounded == true)
        {
            rb.AddForce(new Vector2(0, speedY)); //Se mueve con un AddForce
            Debug.Log("Salto");

        }
        
        //Invoco animacion
        Animation();
    }


    //Check de parametros Booleanos del Animator
    public void Animation()
    {
        
        //Corriendo
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", true);
            Debug.Log("Corriendo");
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", true);
            Debug.Log("Idle");
        }
        
        //Saltando
        if(Input.GetKey(KeyCode.Space) && check.grounded == true)
        {
            anim.SetBool("isJumping", true);
        }
        
        //Yendo para arriba
        if(check.grounded == false && rb.velocity.y > 0)
        {
            anim.SetBool("isRising", true);
            anim.SetBool("isJumping", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isFalling", false);
        }

        //Cayendo
        if (check.grounded == false && rb.velocity.y < 0)
        {
            anim.SetBool("isFalling", true);
            anim.SetBool("isJumping", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isRising", false);
        }
        else
        {
            anim.SetBool("isFalling", false);
        }
    }
}
