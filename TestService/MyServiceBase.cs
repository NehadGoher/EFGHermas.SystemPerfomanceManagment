using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Web;

namespace TestService
{
    public class MyServiceBase : ServiceBase
    {
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
        }
    }
}