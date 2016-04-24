using System;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using ConsoleApplication2;

class Program
{
    public const string URL = "http://*:8080/";
    static void Main()
    {
        string[] pref = new string[1];
        pref[0] = URL;
        while (true)
        {
            new Server(pref);
        }
    }
}

