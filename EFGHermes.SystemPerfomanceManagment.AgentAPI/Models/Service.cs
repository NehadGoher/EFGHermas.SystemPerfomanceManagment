using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace EFGHermes.SystemPerfomanceManagment.AgentAPI.Models
{
    public class Service
    {
        //public String ServiceId { set; get; }
        public String ServiceName { set; get; }
        public String DisplayName { set; get; }
        public ServiceControllerStatus Status { set; get; }
        public string DBName { get; set; }
        public string dbServerName { get; set; }
        public String MachineName { get; set; }
        public List<string> ClienEndpointAddresses;
        public List<string> ClienContractNames;
        public List<string> ServiceEndpointAddresses;
        public List<string> ServiceContractNames;
        public Service()
        {
            ClienEndpointAddresses = new List<string>();
            ClienContractNames = new List<string>();
            ServiceEndpointAddresses = new List<string>();
            ServiceContractNames = new List<string>();

        }

    }

}
