using EFGHermes.SystemPerfomanceManagment.ServerAPI.Services;
using System;
using System.Threading;

namespace ServerApiTestConsoleCore
{
    class Program
    {
        static void Main(string[] args)
        {

            // var timer1 = new Timer(_ => Console.WriteLine("Hello World"), null, 0, 2000);
            Agent agent = new Agent("https://localhost:44396/api/services");
            var services = agent.GetServicesAsync().Result;
            foreach (var elem in services)
            {
                Console.WriteLine(elem.DisplayName);

            }
            Console.Read();
        }
    }
}
