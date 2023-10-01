using DomainLayer.Models;
using DomainLayer.Utils.Interfaces;
using ServiceLayer.DelegateTypes;
using ServiceLayer.Models;
using System.Net.Sockets;

namespace UnitTestChatRoomServer.MockClasses
{

    public class Mock_ClientAction : IClientAction
    {

        List<ClientInfo> _allConnectedClients;

        public Mock_ClientAction()
        {
            _allConnectedClients = new List<ClientInfo>();
        }
        public void AddNewClientConnectionToAllConnectedClients(TcpClient client)
        {
            throw new NotImplementedException();
        }

        public List<ClientInfo> GetAllConnectedClients()
        {
            throw new NotImplementedException();
        }

        public void RemoveAllCreatedChatRooms()
        {
            throw new NotImplementedException();
        }

        public void RemoveAllCreatedChatRoomsOnServerStopping()
        {
            throw new NotImplementedException();
        }

        public void ResolveCommunicationFromClient(TcpClient tcpClient, ServerActivityInfo serverActivityInfo)
        {
            throw new NotImplementedException();
        }

        public void SetAllConnectedClients(List<ClientInfo> allConnectedClients)
        {
            _allConnectedClients = allConnectedClients;
        }

        public void SetConnectedClientsListCallback(CustomDelegate.ConnectedClentsListDelegate connectedClientsListCallback)
        {
            throw new NotImplementedException();
        }
    }
}
