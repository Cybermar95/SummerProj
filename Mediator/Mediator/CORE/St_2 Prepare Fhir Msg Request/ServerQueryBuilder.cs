using System;
using System.Net.Http;
using TaskLib;

namespace Mediator
{
    static class ServerQueryBuilder
    {
        private static string ServerEndPoint = String.Concat("http://" + MediatorSettings.FhirServerEndPoint + "/fhir");
        public static HttpRequestMessage ServerRequest(MediatorSTaskType TaskType, string ConvertedData)
        {
            switch (TaskType)
            {
                case MediatorSTaskType.AddClient:
                    return AddClientRequestCreate(ConvertedData);

                case MediatorSTaskType.GetClient:
                    return GetClientRequestCreate(ConvertedData);


                default:
                    throw new Exception("Unidentified Mediator Task Code"); 
            }
        }

        private static HttpRequestMessage AddClientRequestCreate(string ConvertedData)
        {
            string path = "/patient";
            HttpRequestMessage RequestMsg = new HttpRequestMessage(HttpMethod.Post, String.Concat(ServerEndPoint, path));
            RequestMsg.Content = new StringContent(ConvertedData);
            return RequestMsg;
        }

        private static HttpRequestMessage GetClientRequestCreate(string ConvertedData)
        {
            string path = String.Concat("/patient/",ConvertedData);
            HttpRequestMessage RequestMsg = new HttpRequestMessage(HttpMethod.Get, String.Concat(ServerEndPoint, path));
            return RequestMsg;
        }
    }
}
