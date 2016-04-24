using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Newtonsoft.Json;
using Lidgren.Network;
using System.Net;

public class ser : MonoBehaviour {

    public InputField name;
    public InputField family;
    public InputField suffix;
    public InputField gender;
    public InputField birthDate;
    public InputField SocialStatus;
    public InputField polis;
    public InputField Privileges;
    static IPEndPoint ServerEND_Point = new IPEndPoint(new IPAddress(new byte[4] { 95, 31, 16, 180 }), 25000);
    void Start ()
    {
    }
	
	
	void Update ()
    {

	}

    public void send()
    {
        
        Patient PAT = new Patient(name.text, family.text, suffix.text, Convert.ToInt32(gender.text), Convert.ToDateTime(birthDate.text), polis.text, Convert.ToInt32(SocialStatus.text), Convert.ToInt32(Privileges.text));
        string json = JsonConvert.SerializeObject(PAT);

        int ClientPort = 25000;
        string ClientIP = "95.31.16.180";

        NetPeerConfiguration config = new NetPeerConfiguration(" ");
        config.SetMessageTypeEnabled(NetIncomingMessageType.UnconnectedData, true);
        config.Port = 1212;
        NetClient client = new NetClient(config);
        NetOutgoingMessage msg = client.CreateMessage();
        msg.Write((byte)0);
        msg.Write(json);
        client.Start();
        client.SendUnconnectedMessage(msg, ClientIP, ClientPort);


    Debug.Log("ОК");
        

    }

}


class Patient
{
    public Patient(string name, string family, string suffix, int gender, DateTime birthDate, string polis, int SocialStatus, int Privileges)
    {
        this.name = name;
        this.family = family;
        this.suffix = suffix;
        this.gender = gender;
        this.birthDate = birthDate;
        this.polis = polis;
        this.SocialStatus = SocialStatus;
        this.Privileges = Privileges;
    }

    public string name;
    public string family;
    public string suffix;
    public int gender;
    public DateTime birthDate;
    public string polis;
    public int SocialStatus;
    public int Privileges;
}
