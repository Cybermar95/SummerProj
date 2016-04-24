using System;
using Lidgren.Network;
using System.Threading;


namespace Mediator
{
    public class ClientReceiver
    {
        static public void ClientReceiverMethod()
        {
            NetServer MediatorServer = MediatorMain.MediatorServer;

            while (true)
            {
                NetIncomingMessage IncMsg;
                while ((IncMsg = MediatorServer.ReadMessage()) != null)
                {
                    if (IncMsg.MessageType == NetIncomingMessageType.UnconnectedData)
                    {    
                        new PackedETask(IncMsg.SenderEndPoint, IncMsg.ReadByte(), IncMsg.ReadString());
                        Console.WriteLine("Полученны данные от клиента. Конечная точка: " + IncMsg.SenderEndPoint);
                    }
                    MediatorServer.Recycle(IncMsg);
                }
                Thread.Sleep(1);
            }
        }
    }
}

