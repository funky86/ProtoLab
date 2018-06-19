using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] float FollowSmoothSpeed = 1.0f;

	Vector3 OffsetFromPlayer = Vector3.zero;
	bool Moving = false;
	Vector3 MovingDestination = Vector3.zero;

	void Awake ()
	{
		EventsManager.Instance.OnPlayerInit += PlayerInit;
		EventsManager.Instance.OnPlayerMove += PlayerMove;
	}

	void Update ()
	{
		if (Moving) {
			float step = FollowSmoothSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, MovingDestination, step);
			if (transform.position == MovingDestination) {
				Moving = false;
			}
		}
	}

	void PlayerInit (Vector3 position)
	{
		OffsetFromPlayer = transform.position - position;
	}

	void PlayerMove (Vector3 position)
	{
		Moving = true;
		MovingDestination = position + OffsetFromPlayer;
	}
}
