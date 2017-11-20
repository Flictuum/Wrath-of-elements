using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour {

	public int actionMode;

	PlayerManager playerManager;
	MapManager    mapManager;
	GameManager   gameManager;

	public List<Node> neighbourNodes;
	public List<Node> pathNodes;
	
	void Start () {
		actionMode = 2;
		neighbourNodes = null;
		pathNodes = null;

		playerManager = GetComponent<PlayerManager> ();
		mapManager    = FindObjectOfType<MapManager> ();
		gameManager   = FindObjectOfType<GameManager> ();
	}

	void Update () {
		if (Input.GetKeyUp (KeyCode.Alpha1)) {
			if (playerManager != gameManager.activePlayer) return;

			actionMode = 1;
			mapManager.ResetNodes (pathNodes, true);

			Node currentNode = mapManager.GetNodeFromPosition (transform.position);
			neighbourNodes = mapManager.GetSquaredNeighbourNodes (currentNode, playerManager.character.getRangeAttack ());

			foreach (Node neighbour in neighbourNodes) {
				neighbour.item.GetComponent<MeshRenderer> ().material.color = Color.magenta;
			}
		} else if (Input.GetKeyUp (KeyCode.Alpha2)) {
			if (playerManager != gameManager.activePlayer) return;

			actionMode = 2;
			mapManager.ResetNodes (neighbourNodes, true);
		}
	}

	void OnMouseDown() {
		if (gameManager.activePlayer == playerManager) return;

		PlayerManager activePlayer = gameManager.activePlayer;
		PlayerActions activePlayerActions = activePlayer.GetComponent<PlayerActions> ();

		if (activePlayerActions.actionMode != 1) return;

		foreach (Node neighbour in activePlayerActions.neighbourNodes) {
			if (transform.position == neighbour.item.position + Vector3.up) {

				playerManager.character.applyDamage (activePlayer.character.getAttack ());
				Transform healthBar = transform.Find("HealthContainer").transform;
				healthBar.localScale = new Vector3 ((float)playerManager.character.getHp() / (float)playerManager.character.GetTotalHp(), 1, 1);

				activePlayerActions.actionMode = 2;
				mapManager.ResetNodes (activePlayerActions.neighbourNodes, true);

				if (playerManager.character.getHp () <= 0) {
					Destroy (this.gameObject);
				} else {
					gameManager.activePlayer = playerManager;
					actionMode = 2;
				}

				return;
			}
		}
	}
}
