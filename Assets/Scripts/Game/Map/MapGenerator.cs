using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	private MapDisplay mapDisplay = null;

	private float noiseScale = 4;

	public int mapWidth;
	public int mapHeight;
	public int seed;

	// Create an array with the perlin noise values
	float[,] Generate() {
		float[,] noiseMap = new float[mapWidth, mapHeight];

		for (int y = 0; y < mapHeight; y++) {
			for (int x = 0; x < mapWidth; x++) {
				float sampleX = seed + (x / noiseScale);
				float sampleY = seed + (y / noiseScale);

				noiseMap[x,y] = Mathf.PerlinNoise (sampleX, sampleY);
			}
		}

		return noiseMap;
	}

	public void Create(int seed, int width, int height) {
		this.mapWidth = width;
		this.mapHeight = height;
		this.seed = seed;

		mapDisplay = FindObjectOfType<MapDisplay> ();
		mapDisplay.DrawMap (Generate ());
	}

}
