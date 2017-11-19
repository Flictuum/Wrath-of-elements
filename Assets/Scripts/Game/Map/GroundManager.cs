using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour {

	public Color defaultColor;
	public Color hoverColor;
	public Color activeColor;

	bool active;

	MapManager mapManager;
	MapDisplay mapDisplay;
	PlayerManager playerManager;

	// Unity core methods

	void Start() {
		mapManager = FindObjectOfType<MapManager> ();
		mapDisplay = FindObjectOfType<MapDisplay> ();
		playerManager = FindObjectOfType<PlayerManager> ();

		Deselect ();
	}

	// Custom methods

	public void Hover() {
		if (playerManager.selected) {
			mapManager.ResetNodes (playerManager.path, true);

			Vector3 start  = playerManager.transform.position;
			Vector3 target = transform.position;

            playerManager.path = Pathfinder.FindPath (start, target, playerManager.character.getRangeMovement());

			Transform lastItem = null;
			foreach (Node node in playerManager.path) {
				node.item.GetComponent<MeshRenderer> ().material.color = Color.cyan;
				lastItem = node.item;
			}
			lastItem.GetComponent<MeshRenderer> ().material.color = hoverColor;
		} else {
			GetComponent<MeshRenderer> ().material.color = hoverColor;
		}
	}

	public void Select() {
		if (playerManager.selected) {
			playerManager.canMove = true;
		} else {
			GetComponent<MeshRenderer> ().material.color = activeColor;
			active = true;
		}
	}

	public void Deselect() {
		GetComponent<MeshRenderer> ().material.color = defaultColor;
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
