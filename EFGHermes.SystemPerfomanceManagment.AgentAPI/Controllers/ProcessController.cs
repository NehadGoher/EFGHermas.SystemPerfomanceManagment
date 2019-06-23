using EFGHermes.SystemPerfomanceManagment.AgentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EFGHermes.SystemPerfomanceManagment.AgentAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProcessController
    {
        public ActionResult<List<Models.Proc>> Getprocess()
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();
            List<Proc> pros = processes.Select(s => new Proc()
            {
                ProcessName = s.ProcessName,
                ProcessThreads = s.Threads.Count,
                ProcessMemory = s.VirtualMemorySize64,
                ProcessId = s.Id
            }).ToList();
            return pros;
        }

    }
}
