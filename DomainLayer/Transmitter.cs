using DataAccessLayer.Utils.Interfaces;
using DomainLayer.Utils.Interfaces;
using ServiceLayer.Messages;
using System;
using System.IO;
using System.Net.Sockets;
using static ServiceLayer.DelegateTypes.CustomDelegate;

namespace DomainLayer
{
    public class Transmitter : ITransmitter
    {
        IStreamProvider _streamProvider;
        public Transmitter(IStreamProvider streamProvider)
        {
            _streamProvider = streamProvider;
        }


        public string sendMessageToClient(TcpClient tcpClient, string messageLine)
        {
            try
            {
                if (tcpClient == null) { return string.Empty; }
                StreamWriter streamWriter = _streamProvider.CreateStreamWriter(tcpClient.GetStream());
                streamWriter.WriteLine(NotificationMessage.ServerPayload + messageLine);
                streamWriter.Flush();

                return NotificationMessage.MessageSentOk;
            }
            catch (Exception ex)
            {
                string log = NotificationMessage.CRLF + NotificationMessage.Exception + "Problem Sending message to the Client..." + NotificationMessage.CRLF + ex.ToString();
                return log;
            }
        }

        public void ReceiveMessageFromClient(TcpClient tcpClient, MessageFromClientDelegate messageFromClientCallback)
        {
            try
            {
                StreamReader streamReader = _streamProvider.CreateStreamReader(tcpClient.GetStream());
                while (tcpClient.Connected)
                {
                    var input = streamReader.ReadLine(); // blocks here until something is received from client
                    messageFromClientCallback(input);
                    if (input == null)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                string log = NotificationMessage.CRLF + NotificationMessage.Exception + "Problem Reading message from the Client..." + NotificationMessage.CRLF + ex.ToString();
                messageFromClientCallback(log);
            }
        }
    }
}
