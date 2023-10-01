using System.Net.Sockets;
using static ServiceLayer.DelegateTypes.CustomDelegate;

namespace DomainLayer.Utils.Interfaces
{
    public interface ITransmitter
    {
        string sendMessageToClient(TcpClient tcpClient, string messageLine);

        void ReceiveMessageFromClient(TcpClient tcpClient, MessageFromClientDelegate messageFromClientCallback);
    }
}
