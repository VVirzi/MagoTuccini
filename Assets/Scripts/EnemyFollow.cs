using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    
    Rigidbody2D rb2d;
    Component Transform;
    public Vector3 vec;
    public Vector3 distancia;
    public float speed;
    public bool follow;
    public float distanciaDeteccion;

    

    private Animator anim;

    [SerializeField] LayerMask layerPlayer;
    [SerializeField] LayerMask layerLava;
    [SerializeField] float daño;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        follow = false;
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (MainCharacter.Instance != null)
        {
            distancia = (MainCharacter.Instance.transform.position - transform.position);


            if (distancia.magnitude <= distanciaDeteccion)
            {
                Follow();
                follow = true;
            }
            else
            {
                follow = false; 
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsIdle", true);
            }
        }
    }

    private void Follow()
    {
        vec = distancia.normalized;
        if (distancia.normalized.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        rb2d.AddForce(vec * speed, ForceMode2D.Force);
        Unstuck();
        anim.SetBool("IsWalking", true);
        anim.SetBool("IsIdle", false);
    }
    private void Unstuck()
    {
        if(follow && (rb2d.velocity.x == 0))
        {
           rb2d.AddForce(new Vector3(0, 1f, 0), ForceMode2D.Impulse);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (rb2d.IsTouchingLayers(layerPlayer))
        {
            Health_MainCharacter.Instance.daño = daño; //Llama a la funcion Damage
        }
        else
        {
            Health_MainCharacter.Instance.daño = 100f;
        }
        if (rb2d.IsTouchingLayers(layerLava))
        {
            Destroy(gameObject);
        }

    }
}
