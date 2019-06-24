using EFGHermes.SystemPerfomanceManagment.ServerAPI.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFGHermes.SystemPerfomanceManagment.ServerAPI.Hubs
{
    public class UIHub : Hub
    {
        public void getServices()
        {
            List<Service> services;
       //     Clients.All.getServices();

        }

        public void startService(int id)
        {

         //   Clients.All.startService();
        }

        public void stopService(int id)
        {

        //    Clients.All.startService();
        }


    }
}
