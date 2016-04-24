using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mediator
{
    class Log
    {
        private static object LockObj = new object();

        static public void ColorBorder(string title, string Data, ConsoleColor color)
        {
            title = String.Concat("[ ", title, " ]");

            string UpBorder = "\n ╔════════════════════════════════════════════════════════════════════════════╗  ╠════════════════════════════════════════════════════════════════════════════╣ ";
            string DownBorder = " ╚════════════════════════════════════════════════════════════════════════════╝";
            string SideBorder = " ║                                                                            ║ ";

            string curentborder = String.Concat(SideBorder, SideBorder, SideBorder);

            List<string> DataList = new List<string>();


            for (; Data.Length > 76;)
            {
                curentborder = String.Concat(curentborder, SideBorder);
                DataList.Add(Data.Substring(0, 74));
                Data = Data.Remove(0, 74);
            }
            DataList.Add(Data);

            lock (LockObj)
            {
                Console.Write(string.Concat(UpBorder, curentborder, DownBorder));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(4, Console.CursorTop - DataList.Count - 3);
                Console.Write(title);

                Console.SetCursorPosition(3, Console.CursorTop + 1);

                Console.ForegroundColor = color;
                for (int x = 0; x < DataList.Count; x++)
                {
                    Console.SetCursorPosition(3, Console.CursorTop + 1);
                    Console.Write(DataList[x]);
                }
                Console.ResetColor();
                Console.SetCursorPosition(0, Console.CursorTop + 3);
            }
        }

        static public void Interior(string Data)
        {
            string UpBorder = "\n╔══════════════════════════════════════════════════════════════════════════════╗";
            string DownBorder = "╚══════════════════════════════════════════════════════════════════════════════╝";

            lock (LockObj)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(UpBorder);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Data);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(DownBorder);
            }
        }
  

        static public void Error(string Data)
        {
            lock (LockObj)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n╔══════════════════════════════════════════════════════════════════════════════╗");
                Console.SetCursorPosition(3, Console.CursorTop - 1);
                Console.WriteLine("[ ERROR ]");
                Console.WriteLine(Data);
                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
                Console.ResetColor();
            }
        }

        static public void Error(string Error, string Data)
        {
            lock (LockObj)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n╔══════════════════════════════════════════════════════════════════════════════╗");
                Console.SetCursorPosition(3, Console.CursorTop - 1);
                Console.WriteLine(String.Concat("[ ", Error, " ]"));
                Console.WriteLine(Data);
                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
                Console.ResetColor();
            }
        }
    }
}
