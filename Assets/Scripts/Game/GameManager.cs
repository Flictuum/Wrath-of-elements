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

		MapGenerator Generator;
		Generator = Map.transform.GetComponent<MapGenerator> ();
		Generator.Create (Random.Range(0, 100), 30, 30);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
