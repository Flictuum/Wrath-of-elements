﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

	public int seed;
	public Vector2 size;

	public Node[,] nodes;

	public float[,] noiseMap;

	public void Create(int _seed, Vector2 _size) {
		seed = _seed;
		size = _size;
		nodes = new Node[(int)size.x, (int)size.y];

		noiseMap = GetComponent<MapGenerator> ().Generate ();
		GetComponent<MapDisplay> ().DrawMap ();
	}

	public void ResetNodes(List<Node> nodes, bool resetMaterial) {
		if (nodes == null) return;

		foreach (Node node in nodes) {
			if (resetMaterial) {
				node.item.GetComponent<GroundManager> ().OnMouseExit ();
			}
			node.parent = null;
		}
	}

	public bool PositionIsInNodesList(List<Node> nodes, Vector3 position) {
		if (nodes == null) return false;

		foreach (Node node in nodes) {
			if (node.item.position == position) {
				return true;
			}
		}

		return false;
	}

	public Node GetNodeFromPosition(Vector3 position) {
		int x = Mathf.RoundToInt(position.x - 0.5f + size.x / 2);
		int y = Mathf.RoundToInt(position.z - 0.5f + size.y / 2);

		return nodes [x, y];
	}

	public List<Node> GetSquaredNeighbourNodes(Node node, int radius) {
		List<Node> neighbours = new List<Node> ();

		for (int x = -radius; x <= radius; x++) {
			for (int y = -radius; y <= radius; y++) {
				int checkX = node.x + x;
				int checkY = node.y + y;

				if (checkX >= 0 && checkX < size.x && checkY >= 0 && checkY < size.y) {
					neighbours.Add (nodes [checkX, checkY]);
				}
			}
		}

		return neighbours;
	}

	public List<Node> GetNeighbourNodes(Node node) {
		List<Node> neighbours = new List<Node> ();

		for (int x = -1; x <= 1; x++) {
			for (int y = -1; y <= 1; y++) {
				if ((x == 0 && y == 0)
					|| (x == -1 && y == -1)
					|| (x == -1 && y ==  1)
					|| (x ==  1 && y == -1)
					|| (x ==  1 && y ==  1)) continue;

				int checkX = node.x + x;
				int checkY = node.y + y;

				if (checkX >= 0 && checkX < size.x && checkY >= 0 && checkY < size.y) {
					neighbours.Add (nodes [checkX, checkY]);
				}
			}
		}

		return neighbours;
	}

}
