namespace EFGHermes.SystemPerfomanceManagment.ServerAPI.Interfaces
{
    public interface IAgentsController
    {
        void NotifyAgentStarted(string machineName, string hostAddress);
    }
}