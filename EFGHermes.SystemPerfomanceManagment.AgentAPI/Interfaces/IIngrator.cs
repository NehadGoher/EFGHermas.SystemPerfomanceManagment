using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFGHermes.SystemPerfomanceManagment.AgentAPI.Controllers;
using EFGHermes.SystemPerfomanceManagment.AgentAPI.Models;

namespace EFGHermes.SystemPerfomanceManagment.AgentAPI.Interfaces
{
  public  interface IIntegrator
    {
        bool NotifyStart(Service serviceInfo);
        bool NotifyStop(Service serviceInfo);
       
    }
}
