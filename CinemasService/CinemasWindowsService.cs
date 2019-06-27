using Integrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace CinemasService
{
    class CinemasWindowsService : monitorService
    {
        public ServiceHost serviceHost = null;
        public CinemasWindowsService()
        {
            // Name the Windows Service
            ServiceName = "CinemasWindowsService";
        }

        // Start the Windows service.
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
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
            serviceHost = new ServiceHost(typeof(CinemasService));

            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            serviceHost.Open();
        }

        protected override void OnStop()
        {
            base.OnStop();
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
