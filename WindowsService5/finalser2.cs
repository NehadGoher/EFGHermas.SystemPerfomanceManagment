using log4net.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Configuration;
using System.IO;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace WindowsService5
{
    public partial class Finalser2 : monitorService 
    {
        ServiceHost servHost;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static Finalser2()
        {
        
            DOMConfigurator.Configure();
        
        }
        public Finalser2()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //File.AppendAllText(@"C: \Users\hp\Desktop\efgTrain" + "ffff.txt", "SERvice start" + typeof(ServiceEndpoint).ToString());
            //  log.Info("SERvice start"+ typeof(ServiceEndpoint).ToString());
            // PerformanceCounter p = new PerformanceCounter();
            //log.Info(p.CounterName);
            //log.Info(p.Container);
            //log.Info(p.MachineName);
            //log.Info(p.Site);


            //ServiceConfiguration 
            base.OnStart(args);
            servHost = new ServiceHost(typeof(WcfServiceLibrary1.MovieService));


            //log.Info(typeof(ServiceEndpoint).ToString());
            //log.Info(typeof(ServiceMetadataEndpoint).ToString());



            servHost.Open();
        }

        protected override void OnStop()
        {
            // File.AppendAllText(@"C:\Users\hp\Desktop\efgTrain" + "ffff.txt", "SERvice stoped" + typeof(ServiceEndpoint).ToString());
            base.OnStop();
            log.Info("SERvice stoped");
            servHost.Close();
        }
    }
}
