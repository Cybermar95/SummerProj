using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Newtonsoft.Json;
using Lidgren.Network;
using System.Net;

public class RegisterScript : MonoBehaviour {

    public InputField pname;
    public InputField family;
    public InputField suffix;
    public Dropdown gender;
    public Dropdown birthDateD;
    public Dropdown birthDateY;
    public Dropdown birthDateM;
    public Dropdown SocialStatus;
    public InputField polis;
    public Dropdown Privileges;

    Connector connector;



    void Start ()
    {
        connector = GameObject.Find("ConnectorObj").GetComponent<Connector>();
	}
	
	
	void Update ()
    {
        NetIncomingMessage IncMsg;
        while ((IncMsg = connector.client.ReadMessage()) != null)
        {
            if (IncMsg.MessageType == NetIncomingMessageType.UnconnectedData)
            {
                byte Command = IncMsg.ReadByte();
                string data = IncMsg.ReadString();
                if (Command == 0)
                {
                    connector.ID = data;
                    LoadIDScene();
                }
            }
            connector.client.Recycle(IncMsg);
        }
    }

    public void Send()
    {
        string day = birthDateD.captionText.text;
        if (day.Length == 1)
        {
            day = "0" + day;
        }

        string month ="01";
        switch (birthDateM.captionText.text)
        {
            case "Январь":
                month = "01";
                break;
            case "Февраль":
                month = "02";
                break;
            case "Март":
                month = "03";
                break;
            case "Апрель":
                month = "04";
                break;
            case "Май":
                month = "05";
                break;
            case "Июнь":
                month = "06";
                break;
            case "Июль":
                month = "07";
                break;
            case "Август":
                month = "08";
                break;
            case "Сентябрь":
                month = "09";
                break;
            case "Октябрь":
                month = "10";
                break;
            case "Ноябрь":
                month = "11";
                break;
            case "Декабрь":
                month = "12";
                break;
        }

                int igender;
        if (gender.captionText.text == "Мужской")
        {
            igender = 1;
        }
        else
        {
            igender = 2;
        }

        int iPrivileges =0;
        int isoc = 0;
        switch (Privileges.captionText.text)
        {
            case "Не имеет льгот":
                iPrivileges = 0;
                break;
            case "Инвалиды войны":
                iPrivileges = 1;
                break;
            case "Участники Великой Отечественной Войны":
                iPrivileges = 2;
                break;
            case "лица, награжденные знаком \"Жителю блокадного Ленинграда\"":
                iPrivileges = 3;
                break;
            case "инвалиды":
                iPrivileges = 4;
                break;
            case "дети-инвалиды":
                iPrivileges = 5;
                break;
            case "граждане РФ, пострадавшие от радиации":
                iPrivileges = 6;
                break;
        }
        
        switch (SocialStatus.captionText.text)
        {
            case "Работающий пациент трудоспособного возраста ":
                isoc = 0;
                break;
            case "Ребенок - инвалид":
                isoc = 1;
                break;
            case "Участник ВОВ ":
                isoc = 2;
                break;
            case "Ветеран тыла ":
                isoc = 3;
                break;
            case "Воин-интернационалист":
                isoc = 4;
                break;
            case "Участник ликвидации Чернобыльской аварии":
                isoc = 5;
                break;
            case "Участник ликвидации последствий Чернобыльской аварии ":
                isoc = 6;
                break;
            case "Реабилитированный ":
                isoc = 7;
                break;
            case "Блокадник":
                isoc = 8;
                break;
            case "Член семьи погибших военнослужащих":
                isoc = 9;
                break;
            case "Учащийся средней школы или среднего учебного заведения ":
                isoc = 10;
                break;
            case "Студент высшего учебного заведения":
                isoc = 11;
                break;
        }


        string BithData = birthDateY.captionText.text +"-"+ month + "-"  + day;
        Patient PAT = new Patient(pname.text, family.text, suffix.text, igender, BithData, polis.text, isoc, iPrivileges);
        string json = JsonConvert.SerializeObject(PAT);

        NetOutgoingMessage msg = connector.client.CreateMessage();
        msg.Write((byte)0);
        msg.Write(json);

        connector.client.SendUnconnectedMessage(msg, connector.ClientIP, connector.ClientPort);
    }

    public void LoadGetScene()
    {
        Application.LoadLevel("данные о пациенте");
    }

    public void LoadIDScene()
    {
        Application.LoadLevel("ID пациента");
    }
}

class Patient
{
    public Patient(string name, string family, string suffix, int gender, string birthDate, string polis, int SocialStatus, int Privileges)
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
    public string birthDate;
    public string polis;
    public int SocialStatus;
    public int Privileges;
}
