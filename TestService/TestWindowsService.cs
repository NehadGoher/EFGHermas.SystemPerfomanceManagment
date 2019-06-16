using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Web;

namespace TestService
{
    public class TestWindowsService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public TestWindowsService()
        {
            // Name the Windows Service
            ServiceName = "WCFWindowsServiceSample";
        }

        public static void Main()
        {
            ServiceBase.Run(new TestWindowsService());
        }

        // Start the Windows service.
        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            // Create a ServiceHost for the CalculatorService type and 
            // provide the base address.
            serviceHost = new ServiceHost(typeof(Service1));

            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}