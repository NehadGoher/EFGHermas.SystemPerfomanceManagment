using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace EFGHermes.SystemPerfomanceManagment.ServerAPI.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public string DisplayName { get; set; }

        [NotMapped]
        public int[] OutgoingServicesIds
        {
            get
            {
                return OutgoingServices
                    .Select(s => s.ToServiceId).ToArray();
            }
            private set { }
        }

        [NotMapped]
        public int[] IngoingServicesIds
        {
            get
            {
                return IngoingServices
                    .Select(s => s.FromServiceId).ToArray();
            }
            private set { }
        }

        public string DBConnectionString { get; set; }

        public ServiceControllerStatus ServiceStatus { get; set; }

        [ForeignKey(nameof(Agent))]
        public int AgentId { get; set; }

        public Agent Agent { get; set; }


        public virtual ICollection<ServiceRelationship> OutgoingServices { get; set; } = new List<ServiceRelationship>();
        public virtual ICollection<ServiceRelationship> IngoingServices { get; set; } = new List<ServiceRelationship>();
    }
}
