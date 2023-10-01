using DomainLayer.Models;
using static ServiceLayer.DelegateTypes.CustomDelegate;

namespace DomainLayer.Utils.Interfaces
{
    public interface IServerManager
    {
        void SetConnectedClientsListCallback(ConnectedClentsListDelegate connectedClientsListCallback);
        string GetLocalIP();

        void StartServer(ServerActivityInfo serverActivityInfo);

        void StopServer(ServerActivityInfo serverActivityInfo);
    }
}
