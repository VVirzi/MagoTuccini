using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Scarecrow : MonoBehaviour
{

    [SerializeField] public float health;

    CapsuleCollider2D col;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponentInChildren<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // OnTriggerEnter2D(col);
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (col.IsTouchingLayers())
        {
            health -= 200 * (Time.deltaTime);
            anim.SetBool("isDamage", true);
        }
        else
        {
            anim.SetBool("isDamage", false);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
   }
   */
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (col.IsTouchingLayers())
        {
            health -= 200 * (Time.deltaTime);
            anim.SetBool("isDamage", true);
        }
        else
        {
            anim.SetBool("isDamage", false);
        }

        if (health <= 0)
        {
            Destroy(gameObject);

        }
    }
   */

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (col.IsTouchingLayers())
        {
            health -= 200 * (Time.deltaTime);
            anim.SetBool("isDamage", true);
        }
        else
        {
            anim.SetBool("isDamage", false);
        }

        if (health <= 0)
        {
            Destroy(gameObject);

        }
    }
}

