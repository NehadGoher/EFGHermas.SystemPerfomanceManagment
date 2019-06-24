using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFGHermes.SystemPerfomanceManagment.ServerAPI.Models;

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

        // GET: api/Services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            return await _context.Services.ToListAsync();
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
    }
}
