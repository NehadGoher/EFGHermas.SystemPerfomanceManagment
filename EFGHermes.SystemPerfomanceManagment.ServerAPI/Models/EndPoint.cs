using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFGHermes.SystemPerfomanceManagment.ServerAPI.Models
{
    public class EndPoint
    {
        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }

        public string Address { get; set; }
        public string Protocol { get; set; }
    }
}
