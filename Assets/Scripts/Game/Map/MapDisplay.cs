using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour {

	public Transform GroundPrefab;
	public Transform ObstaclePrefab;

	public Transform activeGround;

	void Start() {
		activeGround = null;
	}

	bool IsAnEdge(Vector2 size, Vector2 coords) {
		if (coords.x == 0 || coords.x == size.x - 1 || coords.y == 0 || coords.y == size.y - 1) {
			return true;
		}

		return false;
	}

	Vector3 GetPosition(Vector2 size, Vector2 coords) {
		return new Vector3 (-size.x / 2 + 0.5f + coords.x, 0, -size.y / 2 + 0.5f + coords.y);
	}

	public void DrawMap () {
		MapManager manager = GetComponent<MapManager> ();

		for (int x = 0; x < manager.size.x; x++) {
			Transform container = new GameObject ("Row").transform;
			container.parent = transform;

			for (int y = 0; y < manager.size.y; y++) {
				Vector2 coords = new Vector2 (x, y);
				Vector3 position = GetPosition (manager.size, coords);
				Transform Ground = Instantiate (GroundPrefab, position, Quaternion.Euler(Vector3.right * 90)) as Transform;
				Ground.parent = container;

				Node node = new Node(true, Ground, x, y);

				if (manager.noiseMap [x, y] > 0.6f || IsAnEdge(manager.size, coords)) {
					Transform Obstacle = Instantiate (ObstaclePrefab, position + Vector3.up * 0.5f, Quaternion.identity) as Transform;
					Obstacle.parent = container;
					node.walkable = false;
				}

				manager.nodes [x, y] = node;
			}
		}
	}

}
