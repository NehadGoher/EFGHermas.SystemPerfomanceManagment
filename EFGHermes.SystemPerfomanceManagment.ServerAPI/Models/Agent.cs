using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFGHermes.SystemPerfomanceManagment.ServerAPI.Models
{
    public class Agent
    {
        public int AgentId { get; set; }
        public string MachineName { get; set; }
        public string HostAddress { get; set; }
    }
}
