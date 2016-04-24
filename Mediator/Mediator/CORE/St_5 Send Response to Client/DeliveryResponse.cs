using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;
using System.Net;

namespace Mediator
{
    class DeliveryResponse
    {
        public DeliveryResponse(IPEndPoint EndPoint, byte code, string Data)
        {
            this.EndPoint = EndPoint;
            OutMsg = MediatorMain.MediatorServer.CreateMessage();
            
            OutMsg.Write(code);
            OutMsg.Write(Data);
            MediatorMain.ClientResponseList.Enqueue(this);
            if (MediatorSettings.ShowLog)
            {
                Log.ColorBorder("Sent to: " + EndPoint.ToString(), code.ToString() + Data, ConsoleColor.Cyan);
            }
        }
        NetOutgoingMessage OutMsg;
        IPEndPoint EndPoint;

        public void Send()
        {
            MediatorMain.MediatorServer.SendUnconnectedMessage(OutMsg,EndPoint);
        }
    }
}
