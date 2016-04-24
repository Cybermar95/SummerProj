using System;
using System.IO;
using System.Net;

namespace ConsoleApplication2
{
    internal class Returner
    {

        public Ansver GetInfo(HttpListenerRequest request, HttpListenerResponse response)
        {
            try
            {
                string absolutePath = request.RawUrl;
                Console.WriteLine("������ ���������� �� URL: " + "C://fhir/" + absolutePath.Split('/')[2] + "/" +
                                  absolutePath.Split('/')[3] + ".txt");
                StreamReader reader =
                    new StreamReader("C://fhir/" + absolutePath.Split('/')[2] + "/" + absolutePath.Split('/')[3] +
                                     ".txt");
                string a = reader.ReadToEnd();
                Console.WriteLine("���������� ���������, ������������ ������:");
                Console.WriteLine(a);
                response.StatusCode = (int) HttpStatusCode.OK;
                return new Ansver(a, response);
            }
            catch (Exception exception)
            {
                Console.WriteLine("���������� �������� �������: " + exception.Message);
                response.StatusCode = (int) HttpStatusCode.NotFound;
                return new Ansver(null, response);
            }

        }
    }
}