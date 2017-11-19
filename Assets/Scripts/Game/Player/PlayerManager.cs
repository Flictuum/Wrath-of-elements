using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public bool selected;
	public bool canMove;
	public List<Node> path;
    public ACharacter character;

	void Start () {
		selected = false;
		canMove = false;
		path = null;
	}

    void OnMouseDown()
    {
        selected = !selected;

		if (selected) {
			FindObjectOfType<GameManager> ().selectedPlayer = this;
		} else {
			FindObjectOfType<GameManager> ().selectedPlayer = null;
		}
    }

	public void setType(int type) {
		switch (type) {
		case 1:
			character = new FirePeople ();
			break;
		case 2:
			character = new WaterPeople ();
			break;
		}
		transform.GetComponent<MeshRenderer> ().material = character.getMaterial ();
	}
}
