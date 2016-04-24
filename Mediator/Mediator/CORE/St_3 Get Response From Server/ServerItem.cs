using System;
using System.Net;
using Newtonsoft.Json;
using TaskLib;
using System.Net.Http;


namespace Mediator
{
    class ServerRequestObj
    {
        public ServerRequestObj(IPEndPoint ClientEndPoint, HttpRequestMessage RequestMsg, MediatorSTaskType TaskType)
        {
            this.ClientEndPoint = ClientEndPoint;
            this.TaskType = TaskType;
            this.RequestMsg = RequestMsg;
            MediatorMain.ServerRequestList.Enqueue(this);
        }
        private IPEndPoint ClientEndPoint;
        private HttpRequestMessage RequestMsg;
        public  HttpResponseMessage ResponseMsg { get; private set; }
        private MediatorSTaskType TaskType;

        public async void GetResponse (object Obj)
        {
            if (MediatorSettings.ShowLog)
            {
                if (RequestMsg.Content != null)
                {
                    Log.ColorBorder("Fhir Server Command : " + RequestMsg.Method, RequestMsg.Content.ReadAsStringAsync().Result, ConsoleColor.Magenta);
                }
                else
                {
                    Log.ColorBorder("Fhir Server Command : " + RequestMsg.Method, RequestMsg.RequestUri.OriginalString, ConsoleColor.Magenta);
                }
            }

            try
            {
                ResponseMsg = await MediatorMain.client.SendAsync(RequestMsg);
            }
            catch
            {
                throw new Exception("Fhir Server is unavailable !!!!!!!!!");
            }

            if (MediatorSettings.ShowLog)
            {
                if (ResponseMsg.Content != null && ResponseMsg.Content.ReadAsStringAsync().Result != "")
                {
                    Log.ColorBorder("Request to the server result: " + ResponseMsg.StatusCode, ResponseMsg.Content.ReadAsStringAsync().Result, ConsoleColor.Magenta);
                }
                else
                {
                    Log.ColorBorder(ResponseMsg.RequestMessage.Method + " command result: " + ResponseMsg.StatusCode,"", ConsoleColor.Magenta);
                }
            }

            new ClientResponseBuilder(ClientEndPoint, TaskType, ResponseMsg);
        }
    }
}
