using Microsoft.AspNetCore.Mvc;

namespace EFGHermas.SystemPerfomanceManagment.AgentAPI.Interfaces
{
    public interface IServicesController
    {
        ActionResult<string> GetService([FromBody] string id);
        ActionResult<string> GetServices();
        string StartService([FromBody] string serviceName);
        string StopService([FromBody] string servicename);
    }
}