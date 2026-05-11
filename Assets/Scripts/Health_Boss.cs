using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Health_Boss : MonoBehaviour
{
    public static Health_Boss Instance;
    [SerializeField] float health;
    [SerializeField] float initialHealth;
    public LayerMask layerMask;
    public Image img;

    Collider2D col;

    [SerializeField] GameObject drop1;
    [SerializeField] GameObject drop2;

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
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponentInChildren<Collider2D>();
        initialHealth = health;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (col.IsTouchingLayers(layerMask))
        {
            health -= 15f;
            HealthBar();
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            Drop();
        }
    }
    public void HealthBar() //Actualiza el Fill Amount de la barra de vida
    {
        health = Mathf.Clamp(health, 0, initialHealth);
        img.fillAmount = health / initialHealth;
    }

    public void Drop()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            GameObject spell = Instantiate(drop1, transform.position, transform.rotation);
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            GameObject spell = Instantiate(drop2, transform.position, transform.rotation);
        }
    }
}
