using PresentationLayer.MVVM.Models;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Sockets;

namespace PresentationLayer.Seeding
{
    public static class ClientUserSeeds
    {
        //NOTE: Copy and paste this command in the constructor of the file:
        //AllServerUsersViewModel.cs to see the server users in the view 
        //========
        //ItemsSourceAllUsers = ClientUserSeeds.GetAllClientUsers();
        //===========

        public static ObservableCollection<ClientUserModel> GetAllClientUsers()
        {
            List<ClientInfo> allClientsInfo = CreateClientInfoList();
            ObservableCollection<ClientUserModel> allUsers = new ObservableCollection<ClientUserModel>();
            foreach (ClientInfo client in allClientsInfo)
            {
                var clientUserModel = new ClientUserModel()
                {
                    UserId = (Guid)client.ServerUserID,
                    Username = client.Username,
                    IsConnected = client.TcpClientInfo.Connected,
                    LocalEndpoint = client.TcpClientInfo.Client?.LocalEndPoint?.ToString(),
                    RemoteEndPoint = client.TcpClientInfo.Client?.RemoteEndPoint?.ToString()

                };

                allUsers.Add(clientUserModel);
            }
            return allUsers;
        }
        private static List<ClientInfo> CreateClientInfoList()
        {
            TcpClient client = new TcpClient();
            ClientInfo clientInfo1 = new ClientInfo() 
            { 
                ServerUserID = Guid.NewGuid(),
                Username = "User1",
                TcpClientInfo = client 
            };
            ClientInfo clientInfo2 = new ClientInfo()
            {
                ServerUserID = Guid.NewGuid(),
                Username = "User2",
                TcpClientInfo = client
            };
            ClientInfo clientInfo3 = new ClientInfo()
            {
                ServerUserID = Guid.NewGuid(),
                Username = "User3",
                TcpClientInfo = client
            };
            ClientInfo clientInfo4 = new ClientInfo()
            {
                ServerUserID = Guid.NewGuid(),
                Username = "User4",
                TcpClientInfo = client
            };
            ClientInfo clientInfo5 = new ClientInfo()
            {
                ServerUserID = Guid.NewGuid(),
                Username = "User5",
                TcpClientInfo = client
            };
            ClientInfo clientInfo6 = new ClientInfo()
            {
                ServerUserID = Guid.NewGuid(),
                Username = "User6",
                TcpClientInfo = client
            };

            ClientInfo clientInfo7 = new ClientInfo()
            {
                ServerUserID = Guid.NewGuid(),
                Username = "User7",
                TcpClientInfo = client
            };

            ClientInfo clientInfo8 = new ClientInfo()
            {
                ServerUserID = Guid.NewGuid(),
                Username = "User8",
                TcpClientInfo = client
            };

            ClientInfo clientInfo9 = new ClientInfo()
            {
                ServerUserID = Guid.NewGuid(),
                Username = "User9",
                TcpClientInfo = client
            };

            ClientInfo clientInfo10 = new ClientInfo()
            {
                ServerUserID = Guid.NewGuid(),
                Username = "User10",
                TcpClientInfo = client
            };

            List<ClientInfo> allClients = new List<ClientInfo>();
            allClients.Add(clientInfo1);
            allClients.Add(clientInfo2);
            allClients.Add(clientInfo3);
            allClients.Add(clientInfo4);
            allClients.Add(clientInfo5);
            allClients.Add(clientInfo6);
            allClients.Add(clientInfo7);
            allClients.Add(clientInfo8);
            allClients.Add(clientInfo9);
            allClients.Add(clientInfo10);

            return allClients;
        }

        
    }
}
