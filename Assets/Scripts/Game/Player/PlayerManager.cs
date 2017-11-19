using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public bool selected;
	public bool canMove;
	public List<Node> path;

	void Start () {
		selected = false;
		canMove = false;
		path = null;
	}

	void Update () {
		if (selected) return;

		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			transform.Translate (Vector3.forward);
		}
		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			transform.Translate (Vector3.back);
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			transform.Translate (Vector3.left);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			transform.Translate (Vector3.right);
		}
	}

	void OnMouseDown() {
		selected = !selected;
	}

}
