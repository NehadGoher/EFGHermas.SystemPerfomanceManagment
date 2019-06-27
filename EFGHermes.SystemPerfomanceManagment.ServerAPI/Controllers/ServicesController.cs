using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFGHermes.SystemPerfomanceManagment.ServerAPI.Models;
using System.ServiceProcess;
using Microsoft.AspNetCore.SignalR;
using EFGHermes.SystemPerfomanceManagment.ServerAPI.Hubs;

namespace EFGHermes.SystemPerfomanceManagment.ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ServerContext _context;
        private IHubContext<UIHub> _hub;

        public ServicesController(ServerContext context, IHubContext<UIHub> hub)
        {
            _context = context;
            _hub = hub;
        }

        #region UI Region
        // GET: api/Services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceDTO>>> GetServices()
        {
            var result = await _context.Services
                .Include(s => s.OutgoingServices)
                .Include(s => s.IngoingServices)
                .ToArrayAsync();

            var result2 = result
                .Select(s => new ServiceDTO
                {
                    Id = s.Id,
                    Address = s.Address,
                    DBConnectionString = s.DBConnectionString,
                    ServiceStatus = s.ServiceStatus.ToString(),
                    DisplayName = s.DisplayName,
                    IngoingServicesIds = s.IngoingServicesIds,
                    OutgoingServicesIds = s.OutgoingServicesIds
                }).ToArray();


            return result2;
        }

        // GET: api/Services/5
        [HttpGet("{name}")]
        public async Task<ActionResult<Service>> GetService(string name)
        {
            var service = await _context.Services.FindAsync(name);

            if (service == null)
            {
                return NotFound();
            }
            await _hub.Clients.All.SendAsync("getServices");
            return service;
        }


        private bool ServiceExists(string name)
        {
            return _context.Services.Any(e => e.DisplayName == name);
        }



        #endregion
        private void EditServiceStatus(int Id, ServiceControllerStatus Status)
        {
            Service service = _context.Services.Find(Id);
            service.ServiceStatus = (ServiceControllerStatus)Status;
            _context.SaveChanges();
        }
        #region Agent Region
        public void NotifyServiceStart(AgentService agentService)
        {
            var presistedAgent = _context.Agents.FirstOrDefault(a => a.MachineName == agentService.MachineName);
            Service service = new Service()
            {
                Address = agentService.ServiceEndpointAddresses[0],
                Agent = presistedAgent,
                DBConnectionString = agentService.DBName,
                DisplayName = agentService.DisplayName,
                ServiceStatus = agentService.Status
            };
            var presistedService = _context.Services
                .FirstOrDefault(s => s.DisplayName == service.DisplayName
                || s.Address == service.Address);

            if (presistedService == null)
            {
                _context.Services.Add(service);
                _context.SaveChanges();
            }
            else
            {
                presistedService.Address = agentService.ServiceEndpointAddresses[0];
                presistedService.Agent = presistedAgent;
                presistedService.DBConnectionString = agentService.DBName;
                presistedService.DisplayName = agentService.DisplayName;
                presistedService.ServiceStatus = agentService.Status;
                presistedService.OutgoingServices = new List<ServiceRelationship>();
                _context.SaveChanges();
            }

            foreach (var clientAddress in agentService.ClienEndpointAddresses)
            {
                var client = _context.Services
                    .FirstOrDefault(s => s.Address == clientAddress);
                if (client == null)
                {
                    _context.Services.Add(new Service()
                    {
                        Address = clientAddress
                    });
                    _context.SaveChanges();
                }
                presistedService.OutgoingServices.Add(
                    new ServiceRelationship()
                    {
                        FromService = presistedService,
                        ToService = _context.Services
                        .FirstOrDefault(s => s.Address == clientAddress)
                    });
                _context.SaveChanges();
            }

            //EditServiceStatus(Id, ServiceControllerStatus.Running);
        }
        public void NotIfyServiceStop(int Id)
        {
            EditServiceStatus(Id, ServiceControllerStatus.Stopped);
        }
        #endregion
    }
}
