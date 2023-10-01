using DomainLayer.Utils.Interfaces;
using ServiceLayer.Messages;
using System.Net.Sockets;
using static ServiceLayer.DelegateTypes.CustomDelegate;

namespace UnitTestChatRoomServer.MockClasses
{

    public class Mock_Transmitter : ITransmitter
    {
        public void ReceiveMessageFromClient(TcpClient tcpClient, MessageFromClientDelegate messageFromClientCallback)
        {
            string message = "this is a message";
            messageFromClientCallback(message);
        }

        public string sendMessageToClient(TcpClient tcpClient, string messageLine)
        {
            return NotificationMessage.MessageSentOk;
        }
    }
}
