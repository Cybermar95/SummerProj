using System;
using System.Threading;

namespace Mediator
{
    class ClientSender
    {
        static public void ClientSenderMethod()
        {
            while (true)
            {
                while (!MediatorMain.ClientResponseList.IsEmpty)
                {
                    DeliveryResponse NewDeliveryTask;
                    MediatorMain.ClientResponseList.TryDequeue(out NewDeliveryTask);
                    try
                    {
                        NewDeliveryTask.Send();
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
