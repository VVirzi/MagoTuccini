using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinNivel : MonoBehaviour
{
    //Eventos
    [HideInInspector] public UnityEvent NextLevel = new UnityEvent(); //Creacion de evento
    [HideInInspector] public UnityEvent Win = new UnityEvent(); //Creacion de evento

    public static FinNivel Instance;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        NextLevel.Invoke();
        Win.Invoke();
    }
}
