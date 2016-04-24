using System;
using System.Threading;
using Lidgren.Network;
using System.Net;
using System.Collections.Concurrent;
using System.Net.Http;

namespace Mediator
{
    class MediatorMain
    {
        static int ClientPort = 25000;
        static string ClientIP = "192.168.1.34";

        static int FhirServerPort = 8080;
        static string FhirServerIP = "192.168.1.34";

        static public HttpClient client = new HttpClient();

        static public NetServer MediatorServer;

        static public ConcurrentQueue<PackedETask> PackedSTask = new ConcurrentQueue<PackedETask>();
        //static public ConcurrentQueue<DeliveryTask> DeliveryList = new ConcurrentQueue<DeliveryTask>();

        static void Main()
        {
            ClientServerStart();
            /*Thread SenderThread = new Thread(ServerSender.ServerSenderMethod);
            SenderThread.Start();*/
            Thread TaskHandlerThread = new Thread(STaskHandler.ServerHandlerMethod);
            TaskHandlerThread.Start();
            Thread ReceiverThread = new Thread(ClientReceiver.ClientReceiverMethod);
            ReceiverThread.Start();

            Console.WriteLine("Mediator Start");
        }

        static void ClientServerStart()
        {
            NetPeerConfiguration config = new NetPeerConfiguration(" ");
            config.Port = ClientPort;
            config.LocalAddress = IPAddress.Parse(ClientIP);
            config.MaximumConnections = 10000;
            config.SetMessageTypeEnabled(NetIncomingMessageType.UnconnectedData, true);

            MediatorServer = new NetServer(config);
            MediatorServer.Start();
        }
    }

    class FhirPatient
    {
        public FhirPatient()
        {
        }

        public FhirPatient(Patient Pat)
        {
            resourceType = "Patient";
            extension = new PatientExtension[] { new PatientExtension(Pat.polis, Pat.SocialStatus, Pat.Privileges) };
            name = new HumanName(Pat.family, Pat.name, Pat.suffix);
            switch (Pat.gender)
            {
                case 1:
                    gender = "male";
                    break;

                case 2:
                    gender = "female";
                    break;
            }
            this.birthDate = String.Concat(Pat.birthDate.Year.ToString(), '-', Pat.birthDate.Month.ToString(), '-', Pat.birthDate.Day.ToString());  
        }

        public string resourceType;
        public PatientExtension[] extension;
        public HumanName name;
        public string gender;
        public string birthDate;
        
    }

    class Patient
    {
        public Patient(string name, string family, string suffix, int gender, DateTime birthDate, int polis, int SocialStatus, int Privileges)
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
        public int polis;
        public int SocialStatus;
        public int Privileges;
    }

    class HumanName
    {
        public HumanName()
        {
        }
        public HumanName(string family, string given, string suffix)
        {
            this.family = new string[] { family };
            this.given = new string[] { given };
            this.suffix = new string[] { suffix };
        }

        public string[] family;
        public string[] given;
        public string[] suffix;
    }

    class PatientExtension
    {
        public PatientExtension()
        {
        }

        public PatientExtension(int Polis, int SocStatusCode, int PrivilCode)
        {
            Extension polis = new Extension("Polis", Polis.ToString());
            Extension SocialStatus = new Extension("SocialStatus", new Coding("NON", SocStatusCode.ToString()));
            Extension Privileges = new Extension("Privileges", new Coding("NON", PrivilCode.ToString()));
            extension = new Extension[] { polis, SocialStatus, Privileges};
        }
        public string url = "NON";
        public Extension[] extension;
    }
   
    class Extension
    {
        public Extension()
        { }
        public Extension(string url, string valueString)
        {
            this.url = url;
            this.valueString = valueString;
        }

        public Extension(string url, Coding valueCoding)
        {
            this.url = url;
            this.valueCoding = valueCoding;
        }

        public string url;
        public string valueString;
        public Coding valueCoding;
    }

    class Coding
    {
        public Coding(string SystemUri, string code)
        {
            this.SystemUri = SystemUri;
            this.code = code;
        }

        public string SystemUri;
        public string code;
    }
}
