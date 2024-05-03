using Booky.Core.Ilog;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booky.Repostiory.Log
{
    public class Logging : Ilogging
    {
        public void Log(string message, string type)
        {
            if(type=="error")
            {
                Console.BackgroundColor =ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"error {message}");

            }
            else if(type=="info")
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"info {message}");
            }
            else if (type =="Warning")
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"warning {message}");
            }
        }
    }
}
