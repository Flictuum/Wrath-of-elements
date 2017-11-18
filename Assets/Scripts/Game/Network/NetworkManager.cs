using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour {

	NetworkClient client;

	// Use this for initialization
	void Start () {
		Debug.Log("@ Start");
		SetupServer();
		SetupLocalClient();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetupServer()
	{
		NetworkServer.Listen(8888);
	}

	public void SetupClient()
	{
		client = new NetworkClient();
		client.RegisterHandler(MsgType.Connect, OnConnected);     
		client.Connect("127.0.0.1", 8888);
	}

	public void SetupLocalClient()
	{
		client = ClientScene.ConnectLocalServer();
		client.RegisterHandler(MsgType.Connect, OnConnected);     
	}

	public void OnConnected(NetworkMessage netMsg)
	{
		Debug.Log("Connected to server");
	}
}
