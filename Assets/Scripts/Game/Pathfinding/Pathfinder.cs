using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

	public static List<Node> FindPath(Vector3 start, Vector3 target, int maxMoves) {
		MapManager mapManager = FindObjectOfType<MapManager> ();

		Node startNode  = mapManager.GetNodeFromPosition (start);
		Node targetNode = mapManager.GetNodeFromPosition (target);

		List<Node> openSet = new List<Node> ();
		HashSet<Node> closedSet = new HashSet<Node> ();

		openSet.Add (startNode);

		while (openSet.Count > 0) {
			Node currentNode = openSet [0];

			for (int i = 1; i < openSet.Count; i++) {
				if (openSet [i].fCost < currentNode.fCost
					|| openSet[i].fCost == currentNode.fCost
					&& openSet[i].hCost  < currentNode.hCost) {
					currentNode = openSet [i];
				}
			}

			openSet.Remove (currentNode);
			closedSet.Add (currentNode);

			if (Pathfinder.CountMoves(currentNode) == maxMoves) {
				return Pathfinder.GetPath (currentNode);
			}

			if (currentNode == targetNode) {
				return Pathfinder.GetPath (targetNode);
			}

			foreach (Node neighbour in mapManager.GetNeighbourNodes(currentNode)) {
				if (!neighbour.walkable || closedSet.Contains (neighbour)) continue;

				int movementToNeighbourCost = currentNode.gCost + Pathfinder.GetDistance (currentNode, neighbour);

				if (movementToNeighbourCost < neighbour.gCost || !openSet.Contains (neighbour)) {
					neighbour.gCost = movementToNeighbourCost;
					neighbour.hCost = Pathfinder.GetDistance (neighbour, targetNode);
					neighbour.parent = currentNode;

					if (!openSet.Contains (neighbour)) {
						openSet.Add (neighbour);
					}
				}
			}
		}

		return null;
	}

	public static int CountMoves(Node current) {
		int count = 0;

		while (current != null) {
			count++;
			current = current.parent;
		}

		return count - 1;
	}

	public static int GetDistance(Node a, Node b) {
		int distX = Mathf.Abs (a.x - b.x);
		int distY = Mathf.Abs (a.y - b.y);

		if (distX > distY) {
			return 14 * distY + 10 * (distX - distY);
		} else {
			return 14 * distX + 10 * (distY - distX);
		}
	}

	public static List<Node> GetPath(Node target) {
		List<Node> path = new List<Node> ();

		while (target != null) {
			path.Add (target);
			target = target.parent;
		}

		path.Reverse ();
		return path;
	}

}
