using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject MapPrefab;
	public GameObject PlayerPrefab;

	GameObject map;
	GameObject player;

	void Start() {
		CreateMap ();
		SpawnPlayer ();
	}

	void CreateMap() {
		map = Instantiate (MapPrefab);
		map.name = "Map";
		map.transform.parent = transform;

		MapManager mapManager;
		mapManager = map.transform.GetComponent<MapManager> ();
		mapManager.Create (Random.Range(0, 100), new Vector2(30, 30));
	}

	void SpawnPlayer() {
		MapManager mapManager;
		mapManager = map.transform.GetComponent<MapManager> ();

		int baseX = Random.Range (1, (int)mapManager.size.x - 2);
		int baseY = Random.Range (1, (int)mapManager.size.y - 2);

		Vector3 position = Vector3.zero;
		bool positionFound = false;

		if (mapManager.nodes [baseX, baseY].walkable) {
			position = mapManager.nodes [baseX, baseY].item.position + Vector3.up;
		} else {
			for (int x = baseX; x < mapManager.size.x && !positionFound; x++) {
				for (int y = baseY; y < mapManager.size.y; y++) {
					if (mapManager.nodes [x, y].walkable) {
						position = mapManager.nodes [x, y].item.position + Vector3.up;
						positionFound = true;
						break;
					}
				}
			}
		}

		player = Instantiate (PlayerPrefab, position, Quaternion.identity);
		player.name = "Player";
		player.transform.parent = transform;
	}

}
