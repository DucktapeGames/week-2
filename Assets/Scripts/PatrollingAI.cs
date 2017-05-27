using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingAI : AIStateMachine {
	override protected void Init() {
		base.Init ();
		movement.target = patrolWaypoints[0];
		movement.Begin();
		currentState = State.Patrolling;
	}

	override protected void Patrolling() {
		if (RaycastPlayer()) {
			movement.Stop();
			currentState = State.PlayerSeen;
		}

		base.Patrolling();
	}
}
