using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCanonController : MonoBehaviour
{
	[SerializeField] GameObject CannonBulletPrefab;
	[SerializeField] float Power = 1.0f;

	public void Fire (Vector3 target)
	{
		Vector3 direction = (target - transform.position).normalized;

		GameObject bullet = Instantiate (CannonBulletPrefab, transform.position, transform.rotation);
		bullet.GetComponent<Rigidbody> ().velocity = direction * Power;
	}
}
