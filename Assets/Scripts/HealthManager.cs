using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{

    public static HealthManager Instance;


    //Eventos
    [HideInInspector] public UnityEvent OnDeath = new UnityEvent(); //Creacion de evento

   
    //Action
    public UnityAction<HealthManager, float> UpdateLifeBar;


    /////////////// [SerializeField] private Health_MainCharacter personaje;
    public float health;
    public float initialHealth;
    public bool isAlive;
    public Image img;

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

        isAlive = true;
        initialHealth = Health_MainCharacter.Instance.vidaMago;


        Health_MainCharacter.Instance.BarUpdate.AddListener(HealthBar); //Lo añado al evento BarUpdate y llama a HealthBar
        Health_MainCharacter.Instance.Muerte.AddListener(Dead); //Lo añado al evento Muerte y llama a Dead

    }
    public void Dead()
    {
        if (Health_MainCharacter.Instance.vidaMago <= 0)
        {
            Debug.Log("Dead");
            isAlive = false;
            OnDeath.Invoke(); //Invoca al evento OnDeath en el GameManager  
        }
    }
    public void HealthBar() //Actualiza el Fill Amount de la barra de vida
    {
        Health_MainCharacter.Instance.vidaMago = Mathf.Clamp(Health_MainCharacter.Instance.vidaMago, 0, initialHealth);
        img.fillAmount = Health_MainCharacter.Instance.vidaMago / initialHealth;
        Debug.Log("BarradeVida");
    }
}
