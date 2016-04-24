using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Newtonsoft.Json;
using Lidgren.Network;
using System.Net;


public class IdScript : MonoBehaviour {

    Connector connector;
    public Text text;

    void Start ()
    {
        connector = GameObject.Find("ConnectorObj").GetComponent<Connector>();
        Debug.Log(connector.ID);
        text.text = connector.ID;
    }
	
	
	void Update ()
    {
	
	}
    public void OK()
    {
        Application.LoadLevel(0);
    }
}
