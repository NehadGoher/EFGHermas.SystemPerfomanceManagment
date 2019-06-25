using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EFGHermes.SystemPerfomanceManagment.ServerAPI.Interfaces;
using EFGHermes.SystemPerfomanceManagment.ServerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                    client.GetAsync("api/services");
                }
            }
        }
    }
}