using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossLvl2 : MonoBehaviour
{
    public float radius = 2f;
	public float timeExplotion = 2f;
	[SerializeField] float explotionForce;
	[SerializeField] float dañoBomba;
	public LayerMask layerMask;
	private Vector3 distancia;
	public bool dentro = false;

	//Contador
	private float currentTime = 0f;

	//Follow
	Rigidbody2D rb2d;
	Component Transform;
	public Vector3 vec;
	public float speed;
	public bool follow;
	public float distanciaDeteccion;

	//Animaciones
	Animator anim;

	public static MainCharacter player;

	public UnityEvent DeathBoss = new UnityEvent(); //Creacion de evento



	private void Start()
    {
		rb2d = GetComponent<Rigidbody2D>();
		follow = false;
		player = MainCharacter.Instance;
		anim = GetComponent<Animator>();
	}



    private void FixedUpdate()
	{
		if (player != null)
		{
			distancia = (player.transform.position - transform.position);

			if (distancia.magnitude > radius && distancia.magnitude < distanciaDeteccion)
			{
				Follow();
				follow = true;

			}
			else
			{
				follow = false;
			}

			if (distancia.magnitude <= radius)
			{
				currentTime += Time.deltaTime;
				if (currentTime >= timeExplotion)
				{
					dentro = true;
					Invoke("Attack", 1);
				}
			}
			else
			{
				dentro = false;
				currentTime = 0f;
			}
		}
		Animation();
	}

	private void Attack()
    {
		Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);

		for (int i = 0; i < cols.Length; i++)
		{
			Collider2D col = cols[i];
		}

		foreach (Collider2D col in cols)
		{
			Rigidbody2D rb2DCol = col.gameObject.GetComponent<Rigidbody2D>();
			if (rb2DCol)
			{
				col.gameObject.transform.position += new Vector3(0, 0.5f, 0);
				Vector3 dir = (col.gameObject.transform.position - transform.position).normalized;
				rb2DCol.AddForce(dir * explotionForce, ForceMode2D.Impulse);
			}

			var l_player = col.gameObject.GetComponent<Health_MainCharacter>();

			if (l_player != null)
			{
				Health_MainCharacter.Instance.Damage(dañoBomba);
			}
		}
	}

	private void Follow()
	{
		vec = distancia.normalized;

		if (distancia.normalized.x < 0)
		{
			transform.eulerAngles = new Vector3(0, 180, 0);
		}
		else
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
		}
		rb2d.AddForce(vec * speed, ForceMode2D.Force);

		if (follow && (rb2d.velocity.x == 0))
		{
			Unstuck();
		}
	}
	private void Unstuck()
	{
			rb2d.AddForce(new Vector3(0, 1f, 0), ForceMode2D.Impulse);
	}

	private void Animation()
    {
		distancia = (player.transform.position - transform.position);

		if (distancia.magnitude > radius && distancia.magnitude < distanciaDeteccion)
		{
			anim.SetBool("IsWalking", true);
			anim.SetBool("IsIdle", false);
			anim.SetBool("IsAttacking", false);
		}
		else
		{
			anim.SetBool("IsWalking", false);
			anim.SetBool("IsIdle", true);
			anim.SetBool("IsAttacking", true);
		}

		if (distancia.magnitude <= radius)
		{
			currentTime += Time.deltaTime;
			if (currentTime >= timeExplotion)
			{
				anim.SetBool("IsWalking", false);
				anim.SetBool("IsIdle", false);
				anim.SetBool("IsAttacking", true);
			}
		}
		else
		{
			anim.SetBool("IsAttacking", false);
		}
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
