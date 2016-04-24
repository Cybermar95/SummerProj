using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    internal class Server
    {
        public Server(string[] prefixes)
        {

            HttpListener listener = new HttpListener();

            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }
            listener.Start();
            Console.WriteLine("Запущена прослушка канала...");


            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            this.PrintFields(request);

            Responser _prc = new Responser(request, response);
            _prc.Response();
            //StreamWriter writer = new StreamWriter("C://SavedMsg/new"+i.ToString()+".txt", false, Encoding.UTF8);
            //writer.Write(ansver);
            //i++;
            string responseString;
            if (_prc._ansver.AnsverBody != null)
            {
                responseString = _prc._ansver.AnsverBody;
            }
            else
            {
                responseString = String.Empty;
            }


            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            response = _prc._ansver.Response;
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();

            listener.Stop();
        }

        private void PrintFields(HttpListenerRequest request)
        {
            Console.WriteLine("Тип запроса: " + request.HttpMethod);


            Console.WriteLine("Принятые типы:");
            if (request.AcceptTypes != null)
            {
                foreach (string a in request.AcceptTypes)
                {
                    Console.WriteLine(a);
                }
            }
            else Console.WriteLine("Нет типов");

            Console.WriteLine("Принятые заголовки:");
            if (request.Headers != null)
            {
                foreach (var a in request.Headers)
                {
                    Console.WriteLine(a);
                }
            }

            Console.WriteLine("IP и порт отправителя: " + request.RemoteEndPoint);


            Console.WriteLine("Строка, включенная в запрос: ");
            if (request.QueryString.Count != 0)
            {
                foreach (string a in request.QueryString)
                {
                    Console.WriteLine(a);
                }
            }
            else Console.WriteLine("Нет данных");

            Console.WriteLine("Запрошенный основной путь: " + request.Url.AbsolutePath);
        }
    }

    internal class Responser
    {
        private HttpListenerRequest _request;
        private HttpListenerResponse _response;
        public Ansver _ansver;
        public string ReturnedBody;
        public Responser(HttpListenerRequest request, HttpListenerResponse response)
        {
            _request = request;
            _response = response;
        }

        public bool Response()
        {

            switch (_request.HttpMethod)
            {
                case "POST":
                    Saver svr = new Saver();
                    _ansver = svr.SaveInfo(_request, _response);
                    return true;
                case "GET":
                    Returner rtrn = new Returner();
                    _ansver = rtrn.GetInfo(_request, _response);
                    return true;
                case "PUT":
                    return false;
                case "DELETE":
                    return false;
            }
            return false;
        }

    }

    struct Ansver
    {
        public string AnsverBody;
        public HttpListenerResponse Response;

        public Ansver(string AnsverBody, HttpListenerResponse Response)
        {
            this.AnsverBody = AnsverBody;
            this.Response = Response;
        }

    }
}
