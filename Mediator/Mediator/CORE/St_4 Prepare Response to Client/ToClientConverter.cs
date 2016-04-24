using System;
using Newtonsoft.Json;
using TaskLib;
using System.Net.Http;

namespace Mediator
{
    class ToClientConverter
    {
        public static string TryConvert(MediatorSTaskType TaskType, HttpResponseMessage data)
        {
            switch (TaskType)
            {
                case MediatorSTaskType.AddClient:
                    return AddClientResponseDataConvert(data);

                case MediatorSTaskType.GetClient:
                    return GetClientResponseDataConvert(data);

                default:
                    throw new Exception("Unidentified Mediator Task Code");
            }
        }


        private static string AddClientResponseDataConvert(HttpResponseMessage data)
        {
            if (data.IsSuccessStatusCode)
            {
                return ((string[])data.Headers.GetValues("id"))[0];
            }
            else
            {
                return null;
            }
        }
        private static string GetClientResponseDataConvert(HttpResponseMessage data)
        {
            /*FhirPatient Fpat = JsonConvert.DeserializeObject<FhirPatient>(data.Content.ReadAsStringAsync().Result);
            Patient pat = new Patient();
            pat.birthDate = Fpat.birthDate;
            pat.family = Fpat.name.family[0];
            pat.name = Fpat.name.given[0];
            pat.suffix = Fpat.name.suffix[0];
            pat.polis = Fpat.extension[0].extension[0].valueString;
            pat.SocialStatus = Convert.ToInt32(Fpat.extension[0].extension[1].valueCoding.code);
            pat.Privileges = Convert.ToInt32(Fpat.extension[0].extension[2].valueCoding.code);

            if (Fpat.gender == "male")
                pat.gender = 1;
            else
            {
                pat.gender = 2;
            }
            return JsonConvert.SerializeObject(pat, MediatorSettings.JsonSettings);*/
            return null;
        }
    }
}
