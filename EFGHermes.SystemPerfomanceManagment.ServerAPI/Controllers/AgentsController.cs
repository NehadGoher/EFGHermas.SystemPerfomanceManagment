using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EFGHermes.SystemPerfomanceManagment.ServerAPI.Interfaces;
using EFGHermes.SystemPerfomanceManagment.ServerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EFGHermes.SystemPerfomanceManagment.ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase, IAgentsController
    {
        private readonly ServerContext _context;
        public AgentsController(ServerContext context)
        {
            this._context = context;
        }
        [HttpPost]
        public void NotifyAgentStarted(string machineName, string hostAddress)
        {
            var agent = _context.Agents
                .FirstOrDefault(a => a.MachineName == machineName);
            if (agent == null)
            {
                _context.Agents.Add(new Agent()
                {
                    MachineName = machineName,
                    HostAddress = hostAddress
                });
                _context.SaveChanges();
                var presistedAgent = _context.Agents
                    .FirstOrDefault(a => a.MachineName == machineName);
                
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(hostAddress);
                    var result = client.GetAsync("api/services")
                        .Result.Content.ReadAsStringAsync().Result;
                    AgentService[] agentServices = JsonConvert
                      .DeserializeObject<AgentService[]>(result);

                    foreach (var agentService in agentServices)
                    {
                        Service service = new Service()
                        {
                            Address = agentService.ServiceEndpointAddresses[0],
                            Agent = presistedAgent,
                            DBConnectionString = agentService.DBName,
                            DisplayName = agentService.DisplayName,
                            ServiceStatus = agentService.Status
                        };
                        var presistedService = _context.Services
                            .FirstOrDefault(s => s.Address == service.Address);
                        foreach (var clientAddress in agentService.ClienEndpointAddresses)
                        {
                            var ss = _context.Services
                                .FirstOrDefault(s => s.Address == clientAddress);
                            if (ss == null)
                            {
                                _context.Services.Add(new Service()
                                {
                                    Address = clientAddress
                                });
                                _context.SaveChanges();
                            }
                            service.OutgoingServices.Add(
                                new ServiceRelationship()
                                {
                                    FromService = service,
                                    ToService = _context.Services
                                    .FirstOrDefault(s => s.Address == clientAddress)
                                });
                        }
                        if (presistedService == null)
                        {
                            _context.Services.Add(service);
                            _context.SaveChanges();
                        }
                        else if (presistedService.DisplayName == null || presistedService.DisplayName == "")
                        {
                            presistedService.Address = agentService.ServiceEndpointAddresses[0];
                            presistedService.Agent = presistedAgent;
                            presistedService.DBConnectionString = agentService.DBName;
                            presistedService.DisplayName = agentService.DisplayName;
                            presistedService.ServiceStatus = agentService.Status;
                            _context.SaveChanges();
                        }
                    }

                }
            }
        }
    }
}