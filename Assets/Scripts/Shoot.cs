using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject hechizoPrefab;
    public GameObject hechizo2Prefab;
    public GameObject hechizo3Prefab;
    public float fireRate1 = 0.5f;
    [SerializeField] public float fireRate2;
    private float m_currentTime;
    public bool elemento;
    private float elementoTime;
    public GameObject iconoHielo;
    public GameObject iconoRayo;

    private GroundCheck check;
    Animator anim;
    private MainCharacter mainChar;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        check = GetComponentInParent<GroundCheck>();
        mainChar = GetComponentInParent<MainCharacter>();
        elemento = true;
        iconoHielo.GetComponent<Image>().color = Color.grey;
        iconoRayo.GetComponent<Image>().color = Color.grey;
    }

    // Update is called once per frame
    void Update()
    {
        m_currentTime += Time.deltaTime;
        elementoTime += Time.deltaTime;
        if(Input.GetKey(KeyCode.E) && elemento==false && elementoTime>=1f){
            elemento = true;
            elementoTime = 0;
        }
        
        if(Input.GetKey(KeyCode.E) && elemento && elementoTime>=1f){
            elemento = false;
            elementoTime = 0;
        }
        
        if(elemento)
        {
            iconoHielo.GetComponent<Image>().color = Color.grey;
            iconoRayo.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            iconoHielo.GetComponent<Image>().color = Color.white;
            iconoRayo.GetComponent<Image>().color = Color.grey;
        }

        if(Input.GetKey(KeyCode.F) && m_currentTime>fireRate1 && check.grounded == true && elemento)
        {
            GameObject spell = Instantiate(hechizoPrefab, transform.position, transform.rotation);
            spell.GetComponent<Spell>().SetDirection(transform.right);
            m_currentTime = 0;
            
        }
        
        if (Input.GetKey(KeyCode.F) && m_currentTime > fireRate2 && check.grounded == true && !elemento)
        {
            GameObject spell = Instantiate(hechizo2Prefab, transform.position, transform.rotation);
            spell.GetComponent<Spell>().SetDirection(transform.right);
            m_currentTime = 0;
        }
       
        
        if(Input.GetKey(KeyCode.F)  && check.grounded == true)
        {
            anim.SetBool("isAttacking", true);
            mainChar.speedX = 0;
        }
        else
        {
            anim.SetBool("isAttacking", false);
            mainChar.speedX = mainChar.initialSpeedX;
        }
        
    }
}
