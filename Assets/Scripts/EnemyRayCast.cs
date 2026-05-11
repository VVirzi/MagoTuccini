using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRayCast : MonoBehaviour
{
	[SerializeField] float patrolSpeed = 5.0f;
	public float rayCastDist = -0.82f;
	public LayerMask layerMask;

	private void Update()
	{
		transform.position += transform.right * patrolSpeed * Time.deltaTime;
		
		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, rayCastDist, layerMask);

		if (hit)
		{
			transform.right = transform.right * -1;
		}
		
	}

	
}
