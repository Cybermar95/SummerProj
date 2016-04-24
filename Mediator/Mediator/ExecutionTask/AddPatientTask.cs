using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;

namespace Mediator
{
    class AddPatientTask : ExecutionTask
    {
        public AddPatientTask(IPEndPoint EP, string data)
        {
            this.ClientEndPoint = EP;
            this.data = data;
        }

        IPEndPoint ClientEndPoint;
        string data;

        public void execute()
        {
            string fhir = Translator.PatientToFhirJson(data);
            Console.WriteLine(response(fhir).Result);
        }

        async static Task<string> response(string fhir)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Post, "http://95.31.16.180:8080/fhir/patient");
            msg.Content = new StringContent(fhir);
            try
            {
                HttpResponseMessage x = await MediatorMain.client.SendAsync(msg);

                return (Encoding.UTF8.GetString(await x.Content.ReadAsByteArrayAsync()));
            }
            catch (Exception exception)
            {
                Console.WriteLine(
                    @"Message dont send. Error message: " + exception.Message + "\n" + "Exception method name: " +
                    exception.TargetSite.Name);
                return "";
            }
        }
    }

    class GetPatientTask : ExecutionTask
    {
        public void execute()
        {

        }
    }

    class Translator
    {
        

        public static string PatientToFhirJson(string Patjson)
        {
            JsonSerializerSettings set = new JsonSerializerSettings();

            set.NullValueHandling = NullValueHandling.Ignore;

            Patient pat = JsonConvert.DeserializeObject<Patient>(Patjson);
            FhirPatient Fpat = new FhirPatient(pat);

            return JsonConvert.SerializeObject(Fpat,set);
        }
    }

}
