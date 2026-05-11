using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecionable : MonoBehaviour
{
    [SerializeField] LayerMask player;
    Collider2D col;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (col.IsTouchingLayers(player))
        {
            CollecionableManager.Instance.collecionables += 1;
            Destroy(gameObject);
        }
    }
}
