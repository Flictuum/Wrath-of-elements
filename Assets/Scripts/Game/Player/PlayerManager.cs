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
        character = new FirePeople();
	}

    void OnMouseDown()
    {
        selected = !selected;
    }
}
