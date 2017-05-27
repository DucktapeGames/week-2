using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIMovement))]
public class AIStateMachine : MonoBehaviour {

	public enum State {
		Patrolling,
		Turning,
		Idle,
		PlayerSeen,
		Engaging
	}

	public Vector2[] patrolWaypoints;
	public Vector2 direction;
	public float turnDelay = 1.0f;
	public float playerSeenDelay = 1.0f;

	// TODO: Change to player script
	protected Collider2D player;
	protected AIMovement movement;
	protected Animator animator;
	protected State currentState;

	private int currentWaypoint = 0;

	void Start () {
		movement = GetComponent<AIMovement> ();
		animator = GetComponent<Animator> ();
		Init ();
	}

	void Update () {
		switch (currentState) {
		case State.Idle:
			Idle ();
			break;

		case State.Patrolling:
			Patrolling ();
			break;

		case State.Turning:
			Turning ();
			break;

		case State.PlayerSeen:
			PlayerSeen ();
			break;

		case State.Engaging:
			Engaging ();
			break;
		}
	}

	// Init the state machine
	virtual protected void Init () {
	}

	// Sits there waiting
	virtual protected void Idle () {
		// Do nothing!
	}

	// Patrols looping through waypoints
	virtual protected void Patrolling () {
		if (movement.HasReachedWaypoint ()) {
			var oldWaypoint = currentWaypoint;

			currentWaypoint++;
			currentWaypoint %= patrolWaypoints.Length;

			direction = (patrolWaypoints [currentWaypoint] - patrolWaypoints [oldWaypoint]).normalized;

			movement.target = patrolWaypoints [currentWaypoint];
		}
	}

	// Techincally you are turning but there is not much to do every frame
	// Be sure to stop any turning coroutine before changing state in subclass.
	virtual protected void Turning () {
		// Do nothing
	}

	// Player was spotted! Take a pause and set world state for drama!
	virtual protected void PlayerSeen () {
		if (animator != null) {
			animator.SetTrigger ("PlayerSeen");
		}

		// TODO: Set world state

		// Delays the change of state from PlayerSeen to Engaging
		StartCoroutine (PlayerSeenDelayer ());
	}

	// On the hunt! Go get them tiger!!!
	virtual protected void Engaging () {
		movement.target = movement.map.ToMapPosition (player.transform.position);
		movement.Begin ();
		//TODO: Save world state and load battle scene
		Debug.Log("Player encountered!");
	}

	// Coroutine that spins AI right round baby right round. Like a record baby.
	// Be sure to stop and stop it in subclass at the right moments
	// Hint: Start on Init() and stop before finishing Turning()
	virtual protected IEnumerator TurnPlayer() {
		while (true) {
			switch ((int)direction.x) {
			case 1:
				direction = Vector2.down;
				break;

			case -1:
				direction = Vector2.up;
				break;
			}

			switch ((int)direction.y) {
			case 1:
				direction = Vector2.right;
				break;

			case -1:
				direction = Vector2.left;
				break;
			}

			yield return new WaitForSeconds (turnDelay);
		}
	}
		
	// Tells the AI to look for the player in it's line of site
	// Return true if player is found and sets the player
	protected bool RaycastPlayer() {
		var raycast = Physics2D.Raycast (transform.position, direction);

		if(raycast.collider != null) {
			var collider = raycast.collider;
			
			if (collider.tag == "Player") {
				player = collider;
				return true;
			}
		}

		return false;
	}

	// Player was seen! Pause for dramatic effect and change the AI state
	private IEnumerator PlayerSeenDelayer() {
		yield return new WaitForSeconds (playerSeenDelay);
		currentState = State.Engaging;
	}
}
