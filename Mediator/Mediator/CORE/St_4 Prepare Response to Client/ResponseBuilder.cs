using System;
using System.Net;
using Newtonsoft.Json;
using TaskLib;
using System.Net.Http;

namespace Mediator
{
    class ClientResponseBuilder : MediatorTask
    {
        public ClientResponseBuilder(IPEndPoint ClientEndPoint, MediatorSTaskType TaskType, HttpResponseMessage ResponseMsg)
        {
            this.ClientEndPoint = ClientEndPoint;
            this.ResponseMsg = ResponseMsg;
            this.TaskType = TaskType;
            MediatorMain.MediatorTaskList.Enqueue(this);
        }
        private MediatorSTaskType TaskType;

        private HttpResponseMessage ResponseMsg;
        private IPEndPoint ClientEndPoint;
        private string ConvertedData;

        public void Execute()
        {
            ConvertedData = ToClientConverter.TryConvert(TaskType, ResponseMsg);
            new DeliveryResponse(ClientEndPoint, (byte)TaskType, ConvertedData);
        }
    }
}
