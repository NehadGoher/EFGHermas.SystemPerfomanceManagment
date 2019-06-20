using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace EFGHermas.SystemPerfomanceManagment.AgentAPI.Models
{
    public class Service
    {
        //public String ServiceId { set; get; }
        public String ServiceName { set; get; }
        public String DisplayName { set; get; }
        public ServiceControllerStatus Status { set; get; }
    }
}
