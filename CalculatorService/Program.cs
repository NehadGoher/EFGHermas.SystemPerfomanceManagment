using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace CalculatorService
{
    class Program
    {
        private static void Main(string[] args)
        {
            const string serviceUri = "http://localhost:10000/calc";
            var host = HostFactory.New(c =>
            {
                c.Service<WcfServiceWrapper<Calculator, ICalculator>>(s =>
                {
                    s.SetServiceName("CalculatorService");
                    s.ConstructUsing(x =>
                        new WcfServiceWrapper<Calculator, ICalculator>("Calculator", serviceUri));
                    s.WhenStarted(service => service.Start());
                    s.WhenStopped(service => service.Stop());
                });
                c.RunAsLocalSystem();

                c.SetDescription("Runs CalculatorService.");
                c.SetDisplayName("CalculatorService");
                c.SetServiceName("CalculatorService");
            });

            Console.WriteLine("Hosting ...");
            host.Run();
            Console.WriteLine("Done hosting ...");
        }
    }
}
