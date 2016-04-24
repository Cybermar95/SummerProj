using System.Net;
using TaskLib;
using System.Net.Http;

namespace Mediator
{
    class RequestBuilder : MediatorTask
    {
        public RequestBuilder(IPEndPoint ClientEndPoint, byte TaskType, string ReceivedData)
        {
            this.ClientEndPoint = ClientEndPoint;
            this.ReceivedData = ReceivedData;
            this.TaskType = (MediatorSTaskType)TaskType;
            MediatorMain.MediatorTaskList.Enqueue(this);
        }

        private string ReceivedData;
        private MediatorSTaskType TaskType;

        private string ConvertedData;
        private IPEndPoint ClientEndPoint;
        private HttpRequestMessage RequestMsg;

        public void Execute()
        {
            ConvertedData = ToServerConverter.TryConvert(TaskType, ReceivedData);
            RequestMsg = ServerQueryBuilder.ServerRequest(TaskType, ConvertedData);
            new ServerRequestObj(ClientEndPoint, RequestMsg, TaskType);
        }
    }
}
