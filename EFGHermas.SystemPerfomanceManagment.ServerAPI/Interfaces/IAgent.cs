using EFGHermas.SystemPerfomanceManagment.ServerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFGHermas.SystemPerfomanceManagment.ServerAPI.Interfaces
{
    interface IAgent
    {
        List<Service> GetServices();
        Service GetServiceById(int Id);
        void StartService(int Id);
        void StopService(int Id);
    }
}
