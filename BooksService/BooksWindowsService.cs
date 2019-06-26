using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BooksService
{
    class BooksWindowsService : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public BooksWindowsService()
        {
            // Name the Windows Service
            ServiceName = "BooksWindowsService";
        }

        // Start the Windows service.
        protected override void OnStart(string[] args)
        {
            Start();
        }

        public void Start()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            // Create a ServiceHost for the CalculatorService type and 
            // provide the base address.
            serviceHost = new ServiceHost(typeof(BooksService));

            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            serviceHost.Open();
        }

        protected override void OnStop()
        {
            Stop();
        }

        public new void Stop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}
