using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFGHermes.SystemPerfomanceManagment.ServerAPI.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string IP { get; set; }      //
        public int Port { get; set; }       //

        [NotMapped]
        public Service[] OutgoingServices { get; set; } //

        [NotMapped]
        public Service[] IngoingServices { get; set; } //

        public string DBConnectionString { get; set; }

        public int ServiceStatus { get; set; }


        public virtual List<ServiceRelationship> OutboundServices { get; set; }
    }
}
