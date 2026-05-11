using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Health_MainCharacter : MonoBehaviour
{
    public static Health_MainCharacter Instance;
   

    //Vida
    public float vidaMago;
    public float vidaInicial;


    //Eventos
    [HideInInspector] public UnityEvent BarUpdate = new UnityEvent(); //Creacion de evento BarUpdate
    [HideInInspector] public UnityEvent Muerte = new UnityEvent(); //Creacion de evento Muerte

    //Colisiones
    BoxCollider2D col2D;
    Animator anim;
    public LayerMask enemyMask;
    public LayerMask potionMask;


    //Daño Default 
    public float daño = 100.0f;

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
        col2D = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        SetHealth(); //Llama a la funcion SetHealth 
    }

    public void SetHealth()
    {
        vidaInicial = vidaMago;

        HealthManager.Instance.health = vidaMago; //Actualiza la vida en el HealthManager
        HealthManager.Instance.initialHealth = vidaInicial; //Actualiza la vida inicial en el HealthManager
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (col2D.IsTouchingLayers(enemyMask) && vidaMago > 0f)
        {
            Damage(daño); //Llama a la funcion Damage
        }
        else
        {
            anim.SetBool("isHitted", false);
        }

        if (col2D.IsTouchingLayers(potionMask) && vidaMago < vidaInicial)
        {
            Curacion(); //Llama a la funcion Curacion
        }
        if (vidaMago <= 0)
        {
            Muerte?.Invoke(); //Invoca al evento Muerte para que el HealthManager lo chequee
        }

        HealthManager.Instance.health = vidaMago; //Actualiza la vida en el HealthManager
    }

    public void Curacion()
    {
        Debug.Log("Cured");
        vidaMago += 100.0f * (Time.deltaTime);
        BarUpdate.Invoke(); //Invoca al evento BarUpdate para que el HealthManager lo chequee
    }
    public void Damage(float dañorecibido)
    {
        vidaMago -= dañorecibido* Time.deltaTime;
        Debug.Log("Attacked");
        anim.SetBool("isHitted", true);
        BarUpdate.Invoke(); //Invoca al evento BarUpdate para que el HealthManager lo chequee
    }
    





}
