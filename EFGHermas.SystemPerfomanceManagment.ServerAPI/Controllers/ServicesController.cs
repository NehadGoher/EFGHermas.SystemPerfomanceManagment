using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFGHermas.SystemPerfomanceManagment.ServerAPI.Models;

namespace EFGHermas.SystemPerfomanceManagment.ServerAPI.Controllers
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

        //// PUT: api/Services/5
        //[HttpPut("{name}")]
        //public async Task<IActionResult> PutService(int id, Service service)
        //{
        //    if (id != service.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(service).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ServiceExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Services
        [HttpPost]
        public async Task<ActionResult<Service>> PostService(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetService", new { name = service.DisplayName }, service);
        }

        //// DELETE: api/Services/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Service>> DeleteService(int id)
        //{
        //    var service = await _context.Services.FindAsync(id);
        //    if (service == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Services.Remove(service);
        //    await _context.SaveChangesAsync();

        //    return service;
        //}

        private bool ServiceExists(string name)
        {
            return _context.Services.Any(e => e.DisplayName == name);
        }
    }
}
