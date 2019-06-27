using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace MoviesService
{
    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>                                   //1
            {
                x.Service<MoviesWindowsService>(s =>                                   //2
                {
                    s.ConstructUsing(name => new MoviesWindowsService());                //3
                    s.WhenStarted(tc => tc.Start());                         //4
                    s.WhenStopped(tc => tc.Stop());                          //5
                });
                x.RunAsLocalSystem();                                       //6

                x.SetDescription("Sample Topshelf Host");                   //7
                x.SetDisplayName("EFG.MoviesWindowsService");                                  //8
                x.SetServiceName("EFG.MoviesWindowsService");                                  //9
            });                                                             //10

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  //11
            Environment.ExitCode = exitCode;
            //ServiceBase.Run(new BooksWindowsService());
        }
    }
}

