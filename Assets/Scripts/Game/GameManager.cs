using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject MapPrefab;

	// Use this for initialization
	void Start () {
		CreateMap ();
	}

	void CreateMap () {
		GameObject Map = Instantiate (MapPrefab);
		Map.name = "Map";
		Map.transform.parent = this.transform;

		MapManager mapManager;
		mapManager = Map.transform.GetComponent<MapManager> ();
		mapManager.Create (Random.Range(0, 100), new Vector2(30, 30));
	}

}
