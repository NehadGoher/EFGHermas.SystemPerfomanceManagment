using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Configuration;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService5
{
    public class monitorService: ServiceBase
    {
        ServiceInfo SerInfo = new ServiceInfo();
        protected override void OnStart(string[] args)
        {
            // base.OnStart(args);
            
            SerInfo.ServiceName = ConfigurationManager.AppSettings["ServiceName"];
            SerInfo.ServiceState = ServiceControllerStatus.Running;
            SerInfo.DBName = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString.ToString();
            ServicesSection x = (ServicesSection)ConfigurationManager.GetSection("system.serviceModel/services");

            var serviceModel = ServiceModelSectionGroup.GetSectionGroup(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None));
            var ServiceEndpoints = serviceModel.Services.Services[0].Endpoints;
           // Console.WriteLine(" Service Endpoints ::: ");
            foreach (ServiceEndpointElement e in ServiceEndpoints)
            {
                SerInfo.ServiceEndpointAddresses.Add(e.Address.ToString());
                SerInfo.ServiceContractNames.Add(e.Contract);
            }
           // Console.WriteLine(" Client Endpoints ::: ");
            var ClientEndpoints = serviceModel.Client.Endpoints;
            foreach (ChannelEndpointElement e in ClientEndpoints)
            {
                SerInfo.ClienEndpointAddresses.Add(e.Address.ToString());
                SerInfo.ClienContractNames.Add(e.Contract);
            }

            // send message to agent
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44396/api/");
            client.PostAsJsonAsync<ServiceInfo>("Ingreator", SerInfo);


            string path = @"C:\Users\hp\Desktop\MonitorServiceInfr\test.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to. 
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Hello world, the service has started");
                    sw.WriteLine(SerInfo.ServiceName + " " + SerInfo.ServiceState);
                    sw.WriteLine(SerInfo.DBName);
                    foreach (string line in SerInfo.ServiceEndpointAddresses)
                        sw.WriteLine(line);
                    foreach (string line in SerInfo.ServiceContractNames)
                        sw.WriteLine(line);
                    foreach (string line in SerInfo.ClienEndpointAddresses)
                        sw.WriteLine(line);
                    foreach (string line in SerInfo.ClienContractNames)
                        sw.WriteLine(line);
                }
            }


            //string path = @"C:\Users\hp\Desktop\MonitorServiceInfr\test.txt";
            //if (!File.Exists(path))
            //{
            //    // Create a file to write to. 
            //    using (StreamWriter sw = File.CreateText(path))
            //    {
            //        sw.WriteLine("Hello world, the service has started");
            //        sw.WriteLine(SerInfo.ServiceName + " " + SerInfo.ServiceState);
            //        sw.WriteLine(SerInfo.DBName);
            //        foreach (string line in SerInfo.ServiceEndpointAddresses)
            //            sw.WriteLine(line);
            //        foreach (string line in SerInfo.ServiceContractNames)
            //            sw.WriteLine(line);
            //        foreach (string line in SerInfo.ClienEndpointAddresses)
            //            sw.WriteLine(line);
            //        foreach (string line in SerInfo.ClienContractNames)
            //            sw.WriteLine(line);
            //    }
            //}

            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\hp\Desktop\MonitorServiceInfr\WriteLines2.txt"))
            //{
            //    file.WriteLine(SerInfo.ServiceName + " " + SerInfo.ServiceState);
            //    file.WriteLine(SerInfo.DBName);
            //    foreach (string line in SerInfo.ServiceEndpointAddresses)
            //        file.WriteLine(line);
            //    foreach (string line in SerInfo.ServiceContractNames)
            //        file.WriteLine(line);
            //    foreach (string line in SerInfo.ClienEndpointAddresses)
            //        file.WriteLine(line);
            //    foreach (string line in SerInfo.ClienContractNames)
            //        file.WriteLine(line);
            //}
            //SerInfo.ServiceContractNames= x.Services[0].Endpoints[0].Contract.ToString();

            //ClientSection clientSection = (ClientSection)ConfigurationManager.GetSection("system.serviceModel/client");
            //SerInfo.ClienContractNames = clientSection.Endpoints[0].Contract.ToString();



        }
        protected override void OnStop()
        {
            // base.OnStop();
            SerInfo.ServiceState = ServiceControllerStatus.Stopped;
        }
    }
    public class ServiceInfo
    {
        public string ServiceName { get; set; }
        public ServiceControllerStatus ServiceState { get; set; }
        public string DBName { get; set; }
        public string dbServerName { get; set; }
        public List<string> ClienEndpointAddresses;
        public List<string> ClienContractNames;
        public List<string> ServiceEndpointAddresses;
        public List<string> ServiceContractNames;

        public ServiceInfo()
        {
            ClienEndpointAddresses = new List<string>();
            ClienContractNames = new List<string>();
            ServiceEndpointAddresses = new List<string>();
            ServiceContractNames = new List<string>();

        }

    }

    //protected override void OnStart(string[] args)
    //{
    //    // base.OnStart(args);

    //    SerInfo.ServiceName = ConfigurationManager.AppSettings["ServiceName"];
    //    SerInfo.ServiceState = "Service Runing";
    //    SerInfo.DBName = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString.ToString();
    //    ServicesSection x = (ServicesSection)ConfigurationManager.GetSection("system.serviceModel/services");

    //    var serviceModel = ServiceModelSectionGroup.GetSectionGroup(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None));
    //    var ServiceEndpoints = serviceModel.Services.Services[0].Endpoints;
    //    Console.WriteLine(" Service Endpoints ::: ");
    //    foreach (ServiceEndpointElement e in ServiceEndpoints)
    //    {
    //        SerInfo.ServiceEndpointAddress.Add(e.Address.ToString());
    //    }
    //    Console.WriteLine(" Client Endpoints ::: ");
    //    var ClientEndpoints = serviceModel.Client.Endpoints;
    //    foreach (ChannelEndpointElement e in ClientEndpoints)
    //    {
    //        SerInfo.ClienEndpointAddress.Add(e.Address.ToString());
    //    }
    //    SerInfo.ServiceContractName = x.Services[0].Endpoints[0].Contract.ToString();

    //    ClientSection clientSection = (ClientSection)ConfigurationManager.GetSection("system.serviceModel/client");
    //    SerInfo.ClienContractName = clientSection.Endpoints[0].Contract.ToString();



    //}
}
