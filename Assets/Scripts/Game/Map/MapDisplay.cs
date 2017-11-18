using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour {

	public GameObject wall;
	public GameObject ground;

	public static GroundManager activeGround = null;

	private bool CheckBorders(int width, int height, int x, int y) {
		// We have to add borders to our map
		if (x == 0 || x == width - 1 || y == 0 || y == height - 1) {
			return true;
		}

		return false;
	}

	public void DrawMap (float[,] noiseMap) {
		// Get the width and height of the map
		int width = noiseMap.GetLength (0);
		int height = noiseMap.GetLength (1);

		// As this is a PoC, we can dynamically re-generate the map
		// Destroy old childs
		foreach (Transform child in transform) {
			Destroy (child.gameObject);
		}

		// Instantiate the prefabs based on the perlin noise values
		for (int y = 0; y < height; y++) {
			GameObject row = new GameObject ("Row");
			row.transform.parent = transform;

			for (int x = 0; x < width; x++) {
				GameObject newObject;
				Quaternion rotation = new Quaternion (0, 0, 0, 0);

				// Above a threshold or if it's a border, we create a wall
				if (CheckBorders(width, height, x, y) || noiseMap [x, y] > 0.6f) {
					Vector3 position = new Vector3 (x, .5f, y);
					newObject = Instantiate (wall, position, rotation);
					newObject.name = "Wall";
				// Below, it's the ground
				} else {
					Vector3 position = new Vector3 (x, 0, y);
					newObject = Instantiate (ground, position, rotation);
					newObject.name = "Ground";
				}

				newObject.transform.parent = row.transform;
			}
		}
	}

}
