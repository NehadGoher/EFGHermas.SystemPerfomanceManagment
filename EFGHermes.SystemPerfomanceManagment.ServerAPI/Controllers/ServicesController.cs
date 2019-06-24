using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFGHermes.SystemPerfomanceManagment.ServerAPI.Models;
using System.ServiceProcess;

namespace EFGHermes.SystemPerfomanceManagment.ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ServerContext _context;

        public ServicesController(ServerContext context)
        {
            _context = context;
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
                    IP = s.IP,
                    Port = s.Port,
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
        #region Integrator Region
        public void NotifyServiceStart(int Id)
        {
            EditServiceStatus(Id, ServiceControllerStatus.Running);
        }
        public void NotIfyServiceStop(int Id)
        {
            EditServiceStatus(Id, ServiceControllerStatus.Stopped);
        }
        #endregion
    }
}
