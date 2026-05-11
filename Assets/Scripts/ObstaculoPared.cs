using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoPared : MonoBehaviour
{
    [SerializeField] public float health;
    CapsuleCollider2D col;
    void Start()
    {
        col = GetComponentInChildren<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (col.IsTouchingLayers())
        {
            health -= 200 * (Time.deltaTime);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
