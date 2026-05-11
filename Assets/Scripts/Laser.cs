using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float defDistanceRay;
    //[SerializeField] private float giroAngular;
    public Transform laserFirePoint;
    public LineRenderer m_lineRenderer;
    Transform m_transform;
    public float laserTime = 5.0f;
    public float laserWait = 2.0f;
    private float m_currentTime;
    public LayerMask playerMask;


    private void Awake()
    {
        m_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        m_currentTime += Time.deltaTime;
        //m_transform.Rotate(new Vector3(0f, 0f, giroAngular)*Time.deltaTime);
        if(m_currentTime<laserTime)
        {
            ShootLaser();
        }
        else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.position);
        }
        if(m_currentTime>laserTime+laserWait)
        {
            m_currentTime = 0;
        }
    }

    void ShootLaser()
    {
        if(Physics2D.Raycast(m_transform.position, transform.right))
        {
            
            RaycastHit2D _hit = Physics2D.Raycast(m_transform.position, transform.right);
            Draw2DRay(laserFirePoint.position, _hit.point);
            if (_hit)
            {
                Debug.Log("sdjkf");
            }

        }
        else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
        }

    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRenderer.SetPosition(0, startPos);
        m_lineRenderer.SetPosition(1, endPos);
    }
}
