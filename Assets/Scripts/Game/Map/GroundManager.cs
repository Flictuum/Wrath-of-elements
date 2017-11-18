using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour {

	public Color defaultColor;
	public Color hoverColor;
	public Color activeColor;

	private bool active;

	// Custom methods

	public void Hover() {
		GetComponent<MeshRenderer> ().material.color = hoverColor;
	}

	public void Select() {
		GetComponent<MeshRenderer> ().material.color = activeColor;
		active = true;
	}

	public void Deselect() {
		GetComponent<MeshRenderer> ().material.color = defaultColor;
		active = false;
	}

	// Unity core methods

	void Start() {
		Deselect ();
	}

	// Unity events

	void OnMouseEnter() {
		Hover ();
	}

	void OnMouseExit() {
		if (active) {
			Select ();
		} else {
			Deselect ();
		}
	}

	void OnMouseDown() {
		if (MapDisplay.activeGround && MapDisplay.activeGround != this) {
			MapDisplay.activeGround.Deselect ();
		}

		if (active) {
			Deselect ();
			MapDisplay.activeGround = null;
		} else {
			Select ();
			MapDisplay.activeGround = this;
		}
	}

}
