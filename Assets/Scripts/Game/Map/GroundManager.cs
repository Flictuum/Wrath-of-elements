using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour {

	public Color defaultColor;
	public Color hoverColor;
	public Color hoverAttackColor;
	public Color activeColor;

	bool active;

	MapManager mapManager;
	MapDisplay mapDisplay;
	GameManager gameManager;

	// Unity core methods

	void Start() {
		mapManager  = FindObjectOfType<MapManager> ();
		mapDisplay  = FindObjectOfType<MapDisplay> ();
		gameManager = FindObjectOfType<GameManager> ();

		defaultColor = GetComponent<MeshRenderer> ().material.color;
	}

	// Custom methods

	public void Hover() {
		PlayerActions playerActions = gameManager.activePlayer.GetComponent<PlayerActions> ();

		if (playerActions.actionMode == 2) {
			PlayerManager playerManager = gameManager.activePlayer;

			mapManager.ResetNodes (playerActions.pathNodes, true);

			Vector3 start = playerManager.transform.position;
			Vector3 target = transform.position;

			playerActions.pathNodes = Pathfinder.FindPath (start, target, playerManager.character.getRangeMovement ());

			Transform lastItem = null;
			foreach (Node node in playerActions.pathNodes) {
				node.item.GetComponent<MeshRenderer> ().material.color = Color.cyan;
				lastItem = node.item;
			}
			lastItem.GetComponent<MeshRenderer> ().material.color = hoverColor;
		} else if (playerActions.actionMode == 1
			&& mapManager.PositionIsInNodesList (playerActions.neighbourNodes, transform.position)) {
			GetComponent<MeshRenderer> ().material.color = hoverAttackColor;
		} else {
			GetComponent<MeshRenderer> ().material.color = hoverColor;
		}
	}

	public void Select() {
		PlayerActions playerActions   = gameManager.activePlayer.GetComponent<PlayerActions> ();
		PlayerMovement playerMovement = gameManager.activePlayer.GetComponent<PlayerMovement> ();

		if (playerActions.actionMode == 2) {
			playerMovement.canMove = true;
		} else {
			GetComponent<MeshRenderer> ().material.color = activeColor;
			active = true;
		}
	}

	public void Deselect() {
		PlayerActions playerActions = gameManager.activePlayer.GetComponent<PlayerActions> ();

		if (playerActions.actionMode == 1
		    && mapManager.PositionIsInNodesList (playerActions.neighbourNodes, transform.position)) {
			GetComponent<MeshRenderer> ().material.color = Color.magenta;
		} else {
			GetComponent<MeshRenderer> ().material.color = defaultColor;
		}
		active = false;
	}

	// Unity events

	void OnMouseEnter() {
		Hover ();
	}

	public void OnMouseExit() {
		if (active) {
			Select ();
		} else {
			Deselect ();
		}
	}

	void OnMouseDown() {
		GroundManager activeGround = null;

		if (mapDisplay.activeGround) {
			activeGround = mapDisplay.activeGround.GetComponent<GroundManager> ();
		}

		if (activeGround && activeGround != this) {
			activeGround.Deselect ();
		}

		if (active) {
			Deselect ();
			mapDisplay.activeGround = null;
		} else {
			Select ();
			mapDisplay.activeGround = transform;
		}
	}

}
