using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float radius = 2f;
	public float timeExplotion = 2f;
	public float explotionForce = 5f;
	public LayerMask layerMask;

    private float currentTime = 0f;

	private void Update()
	{
		currentTime += Time.deltaTime;

		if(currentTime > timeExplotion)
		{
			//Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius);
			Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);

			for(int i = 0; i < cols.Length; i++)
			{
				Collider2D col = cols[i];
	
				//Aca empezamos


			}

			foreach (Collider2D col in cols)
			{
				//Aca
				Rigidbody2D rb2DCol = col.gameObject.GetComponent<Rigidbody2D>();
				if (rb2DCol)
				{
					col.gameObject.transform.position += new Vector3(0, 0.5f, 0);
					Vector3 dir = (col.gameObject.transform.position - transform.position).normalized;
					rb2DCol.AddForce(dir * explotionForce, ForceMode2D.Impulse);
					//Destroy(col.gameObject);
				}

			}
			Destroy(gameObject);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
