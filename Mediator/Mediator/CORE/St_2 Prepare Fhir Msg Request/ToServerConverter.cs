using System;
using System.Net;
using Newtonsoft.Json;
using TaskLib;


namespace Mediator
{
    static class ToServerConverter
    {
        public static string TryConvert(MediatorSTaskType TaskType, string data)
        {
            switch (TaskType)
            {
                case MediatorSTaskType.AddClient:
                    return AddClientRequestDataConvert(data);

                case MediatorSTaskType.GetClient:
                    return GetClientRequestDataConvert(data);

                default:
                    throw new Exception("Unidentified Mediator Task Code"); 
            }
        }


        private static string AddClientRequestDataConvert(string data)
        {
            /*Patient pat = JsonConvert.DeserializeObject<Patient>(data);
            FhirPatient Fpat = new FhirPatient(pat);

            return JsonConvert.SerializeObject(Fpat, MediatorSettings.JsonSettings);*/
            return null;
        }
        private static string GetClientRequestDataConvert(string data)
        {
            return data;
        }
    }
}
