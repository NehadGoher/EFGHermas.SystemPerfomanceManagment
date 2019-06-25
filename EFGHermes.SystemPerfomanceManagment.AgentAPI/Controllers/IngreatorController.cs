using EFGHermes.SystemPerfomanceManagment.AgentAPI.Interfaces;
using EFGHermes.SystemPerfomanceManagment.AgentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace EFGHermes.SystemPerfomanceManagment.AgentAPI.Controllers
{
    public class ServiceInfo
    {
        public string ServiceName { get; set; }
        public string ServiceState { get; set; }
        public string DBName { get; set; }
        public string dbServerName { get; set; }
        public String MachineName { get; set; }
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
    [ApiController]
    [Route("/api/[Controller]")]
    public class IngreatorController : IIntegrator
    {
      
        
        // integrator calls this method to notify service started

        [HttpPost]
        public bool NotifyStart(Service serviceInfo)
        {

         

            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("https://localhost:44350/api/");
            HttpContent httpContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("MachineName", serviceInfo.MachineName/*machine name*/),
                new KeyValuePair<string, string>("ServiceName", serviceInfo.ServiceName/*service name*/),
                
            });

            http.PostAsync("services/notifyservicestart",httpContent);
            return true;
        
        }

        // integrator calls this method to notify service stop
        [HttpPost("NotifyStop")]
        public bool NotifyStop(Service serviceInfo)
        {
          
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("https://localhost:44350/api/");
            HttpContent httpContent = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("MachineName", serviceInfo.MachineName/*machine name*/),
                new KeyValuePair<string, string>("ServiceName", serviceInfo.ServiceName/*service name*/),

            });

            http.PostAsync("services/notifyservicestop", httpContent/*post message*/);
            return true;
        
           
            
        }
    }
}
