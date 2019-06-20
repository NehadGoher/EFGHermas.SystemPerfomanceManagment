using EFGHermas.SystemPerfomanceManagment.ServerAPI.Services;
using System;

namespace ServerApiTestConsoleCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Agent agent = new Agent("https://localhost:44396/api/services");
            var services = agent.GetServicesAsync().Result;
            foreach (var elem in services)
            {
                Console.WriteLine(elem.DisplayName);
                
            }
        }
    }
}
