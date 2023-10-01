using DomainLayer.Models;
using ServiceLayer.Models;
using System.Collections.Generic;
using System.Net.Sockets;
using static ServiceLayer.DelegateTypes.CustomDelegate;

namespace DomainLayer.Utils.Interfaces
{
    public interface IClientAction
    {
        void SetAllConnectedClients(List<ClientInfo> allConnectedClients);
        void SetConnectedClientsListCallback(ConnectedClentsListDelegate connectedClientsListCallback);
        List<ClientInfo> GetAllConnectedClients();

        void AddNewClientConnectionToAllConnectedClients(TcpClient client);

        void ResolveCommunicationFromClient(TcpClient tcpClient, ServerActivityInfo serverActivityInfo);

        void RemoveAllCreatedChatRooms();

        void RemoveAllCreatedChatRoomsOnServerStopping();
    }
}
