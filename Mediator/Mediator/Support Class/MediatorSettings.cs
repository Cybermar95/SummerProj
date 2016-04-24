using System;
using Newtonsoft.Json;
using Lidgren.Network;
using System.Net;
using System.Threading;

namespace Mediator
{
    static class MediatorSettings
    {
        private static int MediatorPort = 25000;
        private static string MediatorIP = "127.0.0.1";

        private static int FhirServerPort = 8080;
        private static string FhirServerIP = "127.0.0.1";

        readonly public static string FhirServerEndPoint = string.Concat(FhirServerIP, ':', FhirServerPort.ToString());

        public static int TaskThreadCount = 3;
        public static int RequestPoolCount = 100;

        public static NetPeerConfiguration config = new NetPeerConfiguration(" ");
        public static JsonSerializerSettings JsonSettings = new JsonSerializerSettings();

        public static bool ShowLog = true;

        public static void Initialization()
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, Int16.MaxValue - 1);

            ThreadPool.SetMaxThreads(RequestPoolCount, RequestPoolCount);

            NetPeerConfigInit();
            JsonConfigInit();

            Log.Interior(String.Concat
                (
                "Mediator End Point: ", MediatorIP, ':', MediatorPort,
                "\nFhir server End Point: ", FhirServerIP, ':', FhirServerPort,
                "\nCount of Task thread: ", TaskThreadCount,
                "\nCount of Request Pool: ", RequestPoolCount,
                "\nShow Log: ", ShowLog
                ));
        }

        static void NetPeerConfigInit()
        {
            config.Port = MediatorPort;
            config.LocalAddress = IPAddress.Parse(MediatorIP);
            config.MaximumConnections = 10000;
            config.SetMessageTypeEnabled(NetIncomingMessageType.UnconnectedData, true);
        }

        static void JsonConfigInit()
        {
            JsonSettings.NullValueHandling = NullValueHandling.Ignore;
            JsonSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
        }
    }
}
