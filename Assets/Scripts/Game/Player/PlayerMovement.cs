using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Vector3 startPosition;
	Vector3 targetPosition;

	bool isNotMoving;

	float timeStarted;
	float movementDuration;
	float percentageComplete;

	PlayerManager playerManager;

	int targetIndex;

	void Start() {
		isNotMoving = true;
		movementDuration = 0.25f;
		targetIndex = 0;

		playerManager = GetComponent<PlayerManager> ();
	}

	void Update() {
		if (!playerManager.canMove) return;

		Move (playerManager.path [targetIndex].item.position + Vector3.up);

		if (Finished ()) {
			playerManager.path [targetIndex].item.GetComponent<GroundManager> ().OnMouseExit ();
			targetIndex++;
		}

		if (targetIndex == playerManager.path.Count) {
			playerManager.canMove = false;
			targetIndex = 0;
		}

		playerManager.selected = false;
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
