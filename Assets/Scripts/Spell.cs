using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private float m_speed;
    private Vector3 m_direction;
    public float lifetime = 3f;
    private float m_currentTime;
    Collider2D col2D;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        col2D = GetComponent<Collider2D>();
    }
    public void SetDirection(Vector3 p_direction)
    {
        m_direction = p_direction;
    }
    // Update is called once per frame
    void Update()
    {
        m_currentTime += Time.deltaTime;
        if (m_currentTime > lifetime || col2D.IsTouchingLayers(layerMask))
        {
            Destroy(gameObject);
        }
        transform.position += m_speed * Time.deltaTime * m_direction;
    }

}