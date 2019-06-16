using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFGHermas.SystemPerfomanceManagment.ServerAPI.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public virtual List<EndPoint> EndPoints { get; set; }
        public virtual List<Database> Databases { get; set; }
        public virtual List<ServiceRelationship> OutboundServices { get; set; }
        public int ServiceStatus { get; set; }



    }
}
