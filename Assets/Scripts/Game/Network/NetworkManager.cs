using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : NetworkLobbyManager {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 void OnGUI()
	{
	}

	// ------------------------ lobby server overrides ------------------------

	public override void OnLobbyStartHost()
	{
	}

	public override void OnLobbyStopHost()
	{
	}

	public override void OnLobbyStartServer()
	{
	}

	public override void OnLobbyServerConnect(NetworkConnection conn)
	{
	}

	public override void OnLobbyServerDisconnect(NetworkConnection conn)
	{
	}

	public override void OnLobbyServerSceneChanged(string sceneName)
	{
	}

	public override GameObject OnLobbyServerCreateLobbyPlayer(NetworkConnection conn, short playerControllerId)
	{
		return null;
	}

	public override GameObject OnLobbyServerCreateGamePlayer(NetworkConnection conn, short playerControllerId)
	{
		return null;
	}

	public override void OnLobbyServerPlayerRemoved(NetworkConnection conn, short playerControllerId)
	{
	}

	// for users to apply settings from their lobby player object to their in-game player object
	public override bool OnLobbyServerSceneLoadedForPlayer(GameObject lobbyPlayer, GameObject gamePlayer)
	{
		return true;
	}

	public override void OnLobbyServerPlayersReady()
	{
		// all players are readyToBegin, start the game
		base.OnLobbyServerPlayersReady();
	}

	// ------------------------ lobby client overrides ------------------------

	public override void OnLobbyClientEnter()
	{
	}

	public override void OnLobbyClientExit()
	{
	}

	public override void OnLobbyClientConnect(NetworkConnection conn)
	{
	}

	public override void OnLobbyClientDisconnect(NetworkConnection conn)
	{
	}

	public override void OnLobbyStartClient(NetworkClient lobbyClient)
	{
	}

	public override void OnLobbyStopClient()
	{
	}

	public override void OnLobbyClientSceneChanged(NetworkConnection conn)
	{
	}

	// for users to handle adding a player failed on the server
	public override void OnLobbyClientAddPlayerFailed()
	{
        
	}
}
