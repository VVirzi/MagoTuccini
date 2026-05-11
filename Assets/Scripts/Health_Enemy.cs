using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Enemy : MonoBehaviour
{

    [SerializeField] float health;
    public LayerMask layerMask;


    Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponentInChildren<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (col.IsTouchingLayers(layerMask))
        {
            health -= 15f;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
