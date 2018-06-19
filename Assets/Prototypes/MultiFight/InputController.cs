using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
	[SerializeField] Camera Camera;

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Vector3 position = Input.mousePosition;
			Click (position);
		}
	}

	void Click (Vector3 position)
	{
		Ray ray = Camera.ScreenPointToRay (position);

		RaycastHit rayHit;
		bool hit = Physics.Raycast (ray, out rayHit, 1000.0f);
		if (hit) {
			switch (rayHit.collider.tag) {
			case Constants.TagGround:
				EventsManager.Instance.OnPlayerMove (rayHit.point);
				break;
			case Constants.TagEnemy:
				GameObject enemy = rayHit.collider.gameObject.transform.parent.gameObject;
				EventsManager.Instance.OnAttackEnemy (enemy);
				break;
			}
		}
	}
}
