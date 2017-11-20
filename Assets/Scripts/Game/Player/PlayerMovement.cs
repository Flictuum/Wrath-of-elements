using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	
	public bool canMove;

	Vector3 startPosition;
	Vector3 targetPosition;

	PlayerActions playerActions;

	bool isNotMoving;

	float timeStarted;
	float movementDuration;
	float percentageComplete;

	int targetIndex;

	void Start() {
		isNotMoving = true;
		movementDuration = 0.25f;
		targetIndex = 0;
		canMove = false;

		playerActions = GetComponent<PlayerActions> ();
	}

	void Update() {
		if (!canMove) return;

		playerActions.actionMode = 0;

		Move (playerActions.pathNodes [targetIndex].item.position + Vector3.up);
		if (Finished ()) {
			playerActions.pathNodes [targetIndex].item.GetComponent<GroundManager> ().OnMouseExit ();
			targetIndex++;
		}

		if (targetIndex == playerActions.pathNodes.Count) {
			canMove = false;
			playerActions.actionMode = 2;
			targetIndex = 0;
		}
	}

	void Move(Vector3 _targetPosition) {
		if (transform.position == _targetPosition) return;
		
		if (isNotMoving) {
			isNotMoving = false;
			startPosition  = transform.position;
			targetPosition = _targetPosition;
			timeStarted = Time.time;
		}

		percentageComplete = (Time.time - timeStarted) / movementDuration;
		transform.position = Vector3.Lerp (startPosition, targetPosition, percentageComplete);
	}

	bool Finished() {
		if (percentageComplete < 1.0f && !isNotMoving) {
			return false;
		}

		isNotMoving = true;

		return true;
	}

}
