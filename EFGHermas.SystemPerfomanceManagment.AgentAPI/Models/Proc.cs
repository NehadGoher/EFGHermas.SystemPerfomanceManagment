using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFGHermes.SystemPerfomanceManagment.AgentAPI.Models
{
    public class Proc
    {
        public int ProcessId { set; get; }
        public int ProcessThreads { set; get; }
        public String ProcessName { set; get; }
        public long ProcessMemory { set; get; }
    }
}
