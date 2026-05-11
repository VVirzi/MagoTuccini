using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
 
    CapsuleCollider2D check;
    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        check = GetComponentInChildren<CapsuleCollider2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (check.IsTouchingLayers())
        {
            grounded = true;
            Debug.Log("toca");
        }
        else
        {
            grounded = false;
            Debug.Log("no toca");
        }


        return;
    }

   
}
