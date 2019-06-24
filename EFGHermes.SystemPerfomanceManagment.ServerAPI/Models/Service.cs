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
        public string IP { get; set; }
        public int Port { get; set; }
        public string DisplayName { get; set; }

        [NotMapped]
        public Service[] OutgoingServices
        {
            get
            {
                return ServiceRelationships.Where(s => s.FromServiceId == this.Id)
                    .Select(s => s.ToService).ToArray();
            }
            private set { }
        } //

        [NotMapped]
        public Service[] IngoingServices
        {
            get
            {
                return ServiceRelationships.Where(s => s.ToServiceId == this.Id)
                    .Select(s => s.FromService).ToArray();
            }
            private set { }
        } //

        public string DBConnectionString { get; set; }

        public int ServiceStatus { get; set; }


        public List<ServiceRelationship> ServiceRelationships { get; set; }
    }
}
