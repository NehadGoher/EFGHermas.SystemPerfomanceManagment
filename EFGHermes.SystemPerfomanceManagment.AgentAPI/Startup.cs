using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EFGHermes.SystemPerfomanceManagment.AgentAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();



            // TODO: notify server that agent started
            //
            //
            //

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44350");
                HttpContent content = new FormUrlEncodedContent(
                    new[]
                    {
                        new KeyValuePair<string, string>("MachineName", Environment.MachineName),
                        // TODO: get host address programatically
                        new KeyValuePair<string, string>("HostAddress", "https://localhost:44396")
                    });
                client.PostAsync("Agents", content);
            }

            //try
            //{
            //    HttpClient client = new HttpClient();


            //    string uri = "https://localhost:44350/api/heartbeat";
            //    //HttpContent httpContent = new FormUrlEncodedContent(new[] {
            //    //    new KeyValuePair<string, string>("PCname", Environment.MachineName) });
            //    var timer1 = new Timer(_ => client.GetAsync(uri), null, 0, 2000);
            //    Thread.Sleep(TimeSpan.FromMinutes(1));
            //    //var res = client.GetAsync(uri);
            //    //Console.WriteLine(res.Result.ToString());
            //    //Console.Read();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}



        }
    }
}
