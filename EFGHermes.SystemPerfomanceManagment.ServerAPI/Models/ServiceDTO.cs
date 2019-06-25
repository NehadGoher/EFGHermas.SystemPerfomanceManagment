using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFGHermes.SystemPerfomanceManagment.ServerAPI.Models
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public string DisplayName { get; set; }
        public string DBConnectionString { get; set; }
        public string ServiceStatus { get; set; }
        public int[] OutgoingServicesIds { get; set; }
        public int[] IngoingServicesIds { get; set; }
    }
}
