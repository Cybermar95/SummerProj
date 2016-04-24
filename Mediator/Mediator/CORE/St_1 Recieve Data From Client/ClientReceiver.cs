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
                    try
                    {
                        if (IncMsg.MessageType == NetIncomingMessageType.UnconnectedData)
                        {
                            byte Command = IncMsg.ReadByte();
                            string data = IncMsg.ReadString();
                            new RequestBuilder(IncMsg.SenderEndPoint, Command, data);
                            if (MediatorSettings.ShowLog)
                            {
                                Log.ColorBorder("Received from: " + IncMsg.SenderEndPoint, Command.ToString() + data, ConsoleColor.Cyan);
                            }
                        }
                        MediatorServer.Recycle(IncMsg);
                    }
                    catch (Exception E)
                    {
                        Log.Error(E.Message, E.ToString());
                    }
                }
                Thread.Sleep(1);
            }
        }
    }
}

