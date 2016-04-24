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
        static public HttpClient client = new HttpClient();
        static public NetServer MediatorServer;

        static public ConcurrentQueue<MediatorTask> MediatorTaskList = new ConcurrentQueue<MediatorTask>();
        static public ConcurrentQueue<ServerRequestObj> ServerRequestList = new ConcurrentQueue<ServerRequestObj>();
        static public ConcurrentQueue<DeliveryResponse> ClientResponseList = new ConcurrentQueue<DeliveryResponse>();



        static void Main()
        {
            MediatorStarter();
        }

        static void MediatorStarter()
        {
            try
            {
                MediatorSettings.Initialization();
                ClientServerStart();
                ThreadStarter();
                while (!ServerAvailabilityCheck())
                {
                    Console.ReadKey();
                }
                Log.Interior("Mediator is ready for operation.");
            }
            catch (Exception E)
            {
                Log.Error(E.Message, E.ToString() +  "\n\nException at Startup. \nPress any key to exit.");
                Console.ReadKey();
            }
        } 

        static void ClientServerStart()
        {
            MediatorServer = new NetServer(MediatorSettings.config);
            MediatorServer.Start();
            Log.Interior("Mediator UDP server start successfully");
        }

        static void ThreadStarter()
        {
            Thread SenderThread = new Thread(ClientSender.ClientSenderMethod);
            SenderThread.Start();
            Thread ServerOperations = new Thread(RequestPoolMananger.HandlerMethod);
            ServerOperations.Start();
            for (int x = 0; x < MediatorSettings.TaskThreadCount; x++)
            {
                Thread TaskHandlerThread = new Thread(MediatorTaskHandler.TasksHandlerMethod);
                TaskHandlerThread.Start();
            }
            Thread ReceiverThread = new Thread(ClientReceiver.ClientReceiverMethod);
            ReceiverThread.Start();
            Log.Interior("All thread start successfully.");
        }

        static bool ServerAvailabilityCheck()
        {
            Log.Interior("Fhir HTTP Server is available");
            return true;

            //Log.Error("Server is unavailable");
            //return false;
        }
    }
}