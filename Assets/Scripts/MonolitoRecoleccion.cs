using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonolitoRecoleccion : MonoBehaviour

{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //GetComponent<SpriteRenderer>().enabled = false;
            CollecionableManager.Instance.monolitos += 1;
            Destroy(gameObject);

        }
    }
  
}
