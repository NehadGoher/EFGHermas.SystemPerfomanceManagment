using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.ServiceProcess;
using System.Threading.Tasks;
using EFGHermes.SystemPerfomanceManagment.AgentAPI.Interfaces;
using EFGHermes.SystemPerfomanceManagment.AgentAPI.Models;
using EFGHermes.SystemPerfomanceManagment.ServerAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EFGHermes.SystemPerfomanceManagment.AgentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase, IServicesController
    {

        [HttpGet]
        public ActionResult<List<Service>> GetServices()
        {
            ServiceController[] services = ServiceController.GetServices();
            List<Service> servicesDTOs = services.Select(s => new Service()
            {
                DisplayName = s.DisplayName,
                ServiceName = s.ServiceName,
                Status = s.Status,
                MachineName = s.MachineName
            }).ToList();

            return servicesDTOs;
        }

        [HttpPost]
        public ActionResult<string> GetService([FromBody] string name)
        {
            // TODO: Cake
            return "bahsb";
        }

        [HttpPost("Start")]
        public String StartService([FromRoute] string serviceName)
        {

             ServiceController sc = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName ==serviceName);

             if (sc.Status == ServiceControllerStatus.Stopped)
             {
                 Console.WriteLine("starting{0}service" + serviceName);

                 try
                 {
                     sc.Start();
                     sc.WaitForStatus(ServiceControllerStatus.Running);

                     Console.WriteLine("The {0} service status is now set to {1}.", serviceName, sc.Status.ToString());
                 }
                 catch (InvalidOperationException e)
                 {
                     Console.WriteLine("the{0} service would not start", serviceName);
                     Console.WriteLine(e.Message);

                 }


             }
             else
             {
                 Console.WriteLine("the {0} serivce is already running", serviceName);
             }
            ManageSwrvices.Service1Client client = new ManageSwrvices.Service1Client();
           
            return client.ToString();
            


            /*using (HttpClient client = new HttpClient("http://localhost:52030/Service1.svc/"))
            {

                using (HttpResponseMessage response = client.StartService(serviceName))
                {

                }
            }*/


            

        }

        [HttpPost("Stop")]
        public String StopService([FromRoute]string servicename)
        {
            ServiceController sc = new ServiceController();
            sc.ServiceName = servicename;

            if (sc.Status == ServiceControllerStatus.Running)
            {
                Console.WriteLine("starting{0}service" + servicename);

                try
                {
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped);

                    Console.WriteLine("The {0} service status is now set to {1}.", servicename, sc.Status.ToString());
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("the{0} service cannot  stop", servicename);
                    Console.WriteLine(e.Message);

                }

            }
            else
            {
                Console.WriteLine("the {0} serivce is already running", servicename);
            }
            return sc.ServiceName;
        }

        ActionResult<string> IServicesController.GetServices()
        {
            throw new NotImplementedException();
        }
    }
}
