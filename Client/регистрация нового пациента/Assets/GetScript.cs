using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Newtonsoft.Json;
using Lidgren.Network;
using System.Net;

public class GetScript : MonoBehaviour {

    Connector connector;
    public InputField id;
    public InputField pname;
    public InputField family;
    public InputField suffix;
    public InputField gender;
    public InputField birthDate;
    public InputField SocialStatus;
    public InputField polis;
    public InputField Privileges;

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
                if (Command == 1)
                {
                    SHOW(data);
                }
            }
            connector.client.Recycle(IncMsg);
        }
    }

    void SHOW(string data)
    {
        JsonSerializerSettings Settings = new JsonSerializerSettings();
        Settings.NullValueHandling = NullValueHandling.Ignore;
        Settings.MissingMemberHandling = MissingMemberHandling.Ignore;

        Patient pat = JsonConvert.DeserializeObject<Patient>(data, Settings);

        pname.text = pat.name;
        suffix.text = pat.suffix;
        family.text = pat.family;
        if (pat.gender == 1)
            gender.text = "Мужской";
        else
            gender.text = "женский";
        birthDate.text = pat.birthDate;
        polis.text = pat.polis;

        string mp="";
        string ms="";

        switch (pat.Privileges)
        {
              case 0: 
                mp = "Не имеет льгот";
                break;
            case 1:
                mp = "Инвалиды войны";

                break;
            case 2:
                mp = "Участники Великой Отечественной Войны";

                break;
            case 3:
                mp = "лица, награжденные знаком \"Жителю блокадного Ленинграда\"";
         
                break;
            case 4:
                mp = "инвалиды";
           
                break;
            case 5:
                mp = "дети-инвалиды";
    
                break;
            case 6:
                mp = "граждане РФ, пострадавшие от радиации";
       
                break;
        }


        switch (pat.SocialStatus)
        {
            case 0:
             ms = "Работающий пациент трудоспособного возраста ";
                break;

            case 1:
                ms = "Ребенок - инвалид";
                break;


            case 2:
                ms = "Участник ВОВ ";
                break;

            case 3:
                ms = "Ветеран тыла ";
                break;

            case 4:
                ms = "Воин-интернационалист";
                break;
            case 5:
                ms = "Участник ликвидации Чернобыльской аварии";
            
                break;
            case 6:
                ms = "Участник ликвидации последствий Чернобыльской аварии ";
            
                break;
            case 7:
                ms = "Реабилитированный ";
         
                break;
            case 8:
                ms = "Блокадник";

                break;
            case 9:
                ms = "Член семьи погибших военнослужащих";

                break;
            case 10:
                ms = "Учащийся средней школы или среднего учебного заведения ";

                break;
            case 11:
                ms = "Студент высшего учебного заведения";

                break;
        }




        Privileges.text = mp;
        SocialStatus.text = ms;
    }

    public void Get()
    {
        NetOutgoingMessage msg = connector.client.CreateMessage();
        msg.Write((byte)1);
        msg.Write(Convert.ToInt32(id.text).ToString());

        connector.client.SendUnconnectedMessage(msg, connector.ClientIP, connector.ClientPort);
    }

    public void LoadPostScene()
    {
        Application.LoadLevel("регистрация пациента");
    }
}
