using DataAccessLayer.Utils.Interfaces;
using DomainLayer.Models;
using DomainLayer.Utils.Interfaces;
using ServiceLayer.Messages;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using static ServiceLayer.DelegateTypes.CustomDelegate;

namespace DomainLayer
{
    public class ServerManager : IServerManager
    {
        //Private Variables
        private bool _serverIsActive;
        private TcpListener _tcpListener;
        private string _serverStatusLogger;
        private List<ClientInfo> _allConnectedClients;
        private ConnectedClentsListDelegate _connectedClientsListCallback;

        IClientAction _clientAction;
        IMessageDispatcher _messageDispatcher;
        IDnsProvider _dnsProvider;
        public ServerManager(IClientAction clientAction, IMessageDispatcher messageDispatcher , IDnsProvider dnsProvider)
        {
            _serverIsActive = false;
            _allConnectedClients = new List<ClientInfo>();
            
            
            _clientAction = clientAction;
            _messageDispatcher = messageDispatcher;
            _dnsProvider  = dnsProvider;

            _clientAction.SetAllConnectedClients(_allConnectedClients);
        }


        #region Properties Setters

        public void SetConnectedClientsListCallback(ConnectedClentsListDelegate connectedClientsListCallback)
        {
            _connectedClientsListCallback = connectedClientsListCallback;
        }

        #endregion Properties Setters


        #region Properties Getters
        public string GetLocalIP()
        {
            IPHostEntry host;
            host = _dnsProvider.GetDnsHostEntry();// Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return string.Empty;
        }

        #endregion Properties Getters
        public void StartServer(ServerActivityInfo serverActivityInfo)
        {
            try
            {
                _allConnectedClients.Clear();

                _serverStatusLogger = NotificationMessage.CRLF + "Starting Server...";
                serverActivityInfo.ServerLoggerCallback(_serverStatusLogger);
                Thread threadListener = new Thread(() => {
                    ListenForIncomingConnections(serverActivityInfo);
                });
                threadListener.Name = "ThreadServerListener";
                threadListener.IsBackground = true;
                threadListener.Start();
            }
            catch (Exception ex)
            {
                _serverIsActive = false;
                serverActivityInfo.ServerStatusCallback(_serverIsActive);
                _serverStatusLogger = NotificationMessage.CRLF + NotificationMessage.Exception + "Failure attempting to start the server" + NotificationMessage.CRLF + ex.ToString();
                serverActivityInfo.ServerLoggerCallback(_serverStatusLogger);
            }
        }


        public void StopServer(ServerActivityInfo serverActivityInfo)
        {
            _serverIsActive = false;
            serverActivityInfo.ServerStatusCallback(_serverIsActive);
            _serverStatusLogger = NotificationMessage.CRLF + "Shutting down Server, disconnecting all clients...";
            serverActivityInfo.ServerLoggerCallback(_serverStatusLogger);
            try
            {
                foreach (ClientInfo clientInfo in _allConnectedClients)
                {
                    Guid serverUserId = (Guid)clientInfo.ServerUserID;
                    string messageSent = _messageDispatcher.SendMessageServerStopping(_allConnectedClients, clientInfo);
                    clientInfo?.TcpClientInfo?.Close();
                }

                _clientAction.RemoveAllCreatedChatRoomsOnServerStopping();

                _tcpListener.Stop();
                _allConnectedClients.Clear();
                serverActivityInfo.ConnectedClientsCountCallback(_allConnectedClients.Count);
                _connectedClientsListCallback(_allConnectedClients);
                _serverStatusLogger = NotificationMessage.CRLF + "Server Stopped Successfully.";
                serverActivityInfo.ServerLoggerCallback(_serverStatusLogger);
            }
            catch (Exception ex)
            {
                _serverStatusLogger = NotificationMessage.CRLF + NotificationMessage.Exception + "Problem stopping the server, or client connections forcibly closed..." + NotificationMessage.CRLF + ex.ToString();
                serverActivityInfo.ServerLoggerCallback(_serverStatusLogger);
            }
        }


        #region Private Methods 
        private void ListenForIncomingConnections(ServerActivityInfo serverActivityInfo)
        {
            try
            {
                _serverIsActive = true;
                serverActivityInfo.ServerStatusCallback(_serverIsActive);
                _tcpListener = new TcpListener(IPAddress.Any, serverActivityInfo.Port);
                _tcpListener.Start();
                _serverStatusLogger = NotificationMessage.CRLF + "Server started. Listening on port: " + serverActivityInfo.Port;
                serverActivityInfo.ServerLoggerCallback(_serverStatusLogger);
                while (_serverIsActive)
                {
                    _serverStatusLogger = NotificationMessage.CRLF + "Waiting for incoming client connection...";
                    serverActivityInfo.ServerLoggerCallback(_serverStatusLogger);
                    TcpClient tcpClient = _tcpListener.AcceptTcpClient();   // blocks here until client connects
                    _serverStatusLogger = NotificationMessage.CRLF + "Incoming client connection accepted...";
                    serverActivityInfo.ServerLoggerCallback(_serverStatusLogger);

                    Thread threadWorkerClient = new Thread(() =>
                    {
                        _clientAction.AddNewClientConnectionToAllConnectedClients(tcpClient);
                        serverActivityInfo.ConnectedClientsCountCallback(_allConnectedClients.Count());
                        
                        _clientAction.ResolveCommunicationFromClient(tcpClient, serverActivityInfo);
                    });
                    threadWorkerClient.IsBackground = true;
                    threadWorkerClient.Name = "threadWorkerTcpClient_" + _allConnectedClients.Count();
                    threadWorkerClient.Start();
                }
            }
            catch (SocketException se)
            {
                _tcpListener.Stop();
                _serverStatusLogger = NotificationMessage.CRLF + "Problem starting the server." + NotificationMessage.CRLF + se.ToString();
                serverActivityInfo.ServerLoggerCallback(_serverStatusLogger);
            }
            catch (Exception ex)
            {
                _tcpListener.Stop();
                _serverStatusLogger = NotificationMessage.CRLF + "Problem starting the server." + NotificationMessage.CRLF + ex.ToString();
                serverActivityInfo.ServerLoggerCallback(_serverStatusLogger);
            }

            _serverStatusLogger = NotificationMessage.CRLF + "Exiting listener thread...";
            serverActivityInfo.ServerLoggerCallback(_serverStatusLogger);
        }

        #endregion Private Methods
    }
}
