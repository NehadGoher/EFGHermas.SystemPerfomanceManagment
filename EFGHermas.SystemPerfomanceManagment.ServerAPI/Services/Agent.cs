using EFGHermes.SystemPerfomanceManagment.ServerAPI.Interfaces;
using EFGHermes.SystemPerfomanceManagment.ServerAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EFGHermes.SystemPerfomanceManagment.ServerAPI.Services
{
    public class Agent : IAgent
    {
        private string _uri;
        public Agent(string uri)
        {
            this._uri = uri;
        }

        public async Task<Service> GetServiceById(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(this._uri);
                    var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("name", name.ToString())
            });
                    await client.PostAsync("/services", content);
                    string result = await client.GetStringAsync(this._uri);
                    return JsonConvert.DeserializeObject<Service>(result);
                }
                catch (Exception ex)
                {
                    // Details in ex.Message and ex.HResult.
                    throw ex;
                }
            }
        }
        public async Task<List<Service>> GetServicesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(this._uri);
                    
                    await client.GetAsync("/services");
                    string result = await client.GetStringAsync(this._uri);
                    return JsonConvert.DeserializeObject<List<Service>>(result);
                }
                catch (Exception ex)
                {
                    // Details in ex.Message and ex.HResult.
                    throw ex;
                }
            }
        }

        public void StartService(string name)
        {
            throw new NotImplementedException();
        }

        public void StopService(string name)
        {
            throw new NotImplementedException();
        }
    }
}
