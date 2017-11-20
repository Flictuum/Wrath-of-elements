using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public ACharacter character;

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
