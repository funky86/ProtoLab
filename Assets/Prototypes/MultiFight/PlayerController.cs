using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] float MovingSpeed = 1.0f;
	[SerializeField] WeaponCanonController WeaponCanon;

	bool Moving = false;
	Vector3 MovingDestination = Vector3.zero;

	void Awake ()
	{
		EventsManager.Instance.OnPlayerMove += PlayerMove;
		EventsManager.Instance.OnAttackEnemy += AttackEnemy;
	}

	void Start ()
	{
		EventsManager.Instance.OnPlayerInit (transform.position);
	}

	void Update ()
	{
		if (Moving) {
			float step = MovingSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, MovingDestination, step);
			if (transform.position == MovingDestination) {
				Moving = false;
			}
		}
	}

	void PlayerMove (Vector3 position)
	{
		MovingDestination = position;
		Moving = true;
	}

	void AttackEnemy (GameObject enemy)
	{
		WeaponCanon.Fire (enemy.transform.position);
	}
}
