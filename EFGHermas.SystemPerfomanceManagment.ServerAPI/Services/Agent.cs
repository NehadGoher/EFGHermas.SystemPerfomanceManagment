using EFGHermas.SystemPerfomanceManagment.ServerAPI.Interfaces;
using EFGHermas.SystemPerfomanceManagment.ServerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFGHermas.SystemPerfomanceManagment.ServerAPI.Services
{
    public class Agent : IAgent
    {
        public Service GetServiceById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Service> GetServices()
        {
            throw new NotImplementedException();
        }

        public void StartService(int Id)
        {
            throw new NotImplementedException();
        }

        public void StopService(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
