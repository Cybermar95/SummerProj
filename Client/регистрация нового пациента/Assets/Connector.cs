using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Newtonsoft.Json;
using Lidgren.Network;
using System.Net;

public class Connector : MonoBehaviour {

	NetPeerConfiguration config;
    public  NetClient client;

    public  int ClientPort = 25000;
    public  string ClientIP = "127.0.0.1";

    public string ID = "null";

    void Start ()
    {
        try
        {
			Debug.Log("client try Start");
			config = new NetPeerConfiguration(" ");
			DontDestroyOnLoad(this);

            config.SetMessageTypeEnabled(NetIncomingMessageType.UnconnectedData, true);
            config.Port = 1212;

            client = new NetClient(config);

			client.Start();
            Debug.Log("client Start");
        }
		catch (Exception e )
		{
			Debug.Log (e.Message);
		}
    }
	
	void Update ()
    {
	
	}
}
