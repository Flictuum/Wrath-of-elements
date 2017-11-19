using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	private float noiseScale = 4;

	// Create an array with the perlin noise values
	public float[,] Generate() {
		MapManager manager = GetComponent<MapManager> ();

		float[,] noiseMap = new float[(int)manager.size.x, (int)manager.size.y];

		for (int y = 0; y < manager.size.y; y++) {
			for (int x = 0; x < manager.size.x; x++) {
				float sampleX = manager.seed + (x / noiseScale);
				float sampleY = manager.seed + (y / noiseScale);

				noiseMap[x,y] = Mathf.PerlinNoise (sampleX, sampleY);
			}
		}

		return noiseMap;
	}

}
