using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {

	public bool walkable;
	public Transform item;

	public int x;
	public int y;

	public int gCost;
	public int hCost;

	public Node parent;

	public Node(bool _walkable, Transform _item, int _x, int _y) {
		walkable = _walkable;
		item = _item;
		x = _x;
		y = _y;
		parent = null;
	}

	public int fCost {
		get {
			return gCost + hCost;
		}
	}

}
