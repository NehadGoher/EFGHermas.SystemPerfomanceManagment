using EFGHermes.SystemPerfomanceManagment.ServerAPI.Services;
using System;
using Xunit;

namespace ServerApiTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
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
