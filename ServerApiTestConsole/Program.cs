using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemPerfomanceManagment.ServerAPI.Services;

namespace ServerApiTestConsole
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
