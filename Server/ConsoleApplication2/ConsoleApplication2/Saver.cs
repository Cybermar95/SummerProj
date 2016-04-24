using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace ConsoleApplication2
{
    internal class Saver
    {
        private const string path = "C://fhir//";

        public Ansver SaveInfo(HttpListenerRequest request, HttpListenerResponse response)
        {
            Stream inputStream = request.InputStream;
            Console.WriteLine("Начато сохраниение содержимого");

            Console.WriteLine("Полученные данные из потока:");
            string result = "";
            int last;
            string uriPath = request.Url.AbsolutePath.Split('/')[2];
            try
            {
                byte[] ansver = new byte[request.ContentLength64];
                request.InputStream.Read(ansver, 0, (int)request.ContentLength64);
                result = Encoding.UTF8.GetString(ansver);
                Console.WriteLine(result);

                

                Directory.CreateDirectory(path + uriPath);
                List<string> allfiles = new List<string>(Directory.GetFiles(path + uriPath, "*.txt"));
                allfiles.Sort();
                last = this.GetLast(allfiles);
                StreamWriter writer = new StreamWriter(path + uriPath + "/" + (last).ToString() + ".txt",false, Encoding.UTF8);
               
                writer.Write(result);
                Console.WriteLine("Запись завершена.");
                writer.Close();
                response.AddHeader("id", last.ToString());
                response.StatusCode = (int) HttpStatusCode.Created;
                return new Ansver(null, response);

            }
            catch (Exception exception)
            {
                Console.WriteLine("Запись невозможна, произошла ошибка: " + exception.Message);
                response.StatusCode = (int) HttpStatusCode.InternalServerError;
                return new Ansver(null, response);
            }



        }

        private int GetLast(List<string> allfiles)
        {
            if (allfiles.Count == 0)
            {
                return 0;
            }

            List<int> maxIndex = new List<int>();
            foreach (string a in allfiles)
            {
                string[] aa = a.Split('\\');
                maxIndex.Add(Convert.ToInt32(aa[aa.Length - 1].Replace(".txt", "")));
            }
            maxIndex.Sort();
            return maxIndex[maxIndex.Count-1] + 1;

        }
    }
}