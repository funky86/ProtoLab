using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventsManager
{
	public static EventsManager Instance {
		get {
			if (Instance_ == null) {
				Instance_ = new EventsManager ();
			}
			return Instance_;
		}
	}

	private static EventsManager Instance_;

	private EventsManager ()
	{
		Instance_ = this;
	}

	public Action<Vector3> OnPlayerInit;
	public Action<Vector3> OnPlayerMove;
	public Action<GameObject> OnAttackEnemy;
}
