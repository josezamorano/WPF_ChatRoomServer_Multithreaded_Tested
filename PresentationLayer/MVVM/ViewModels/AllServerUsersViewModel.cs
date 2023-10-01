using DomainLayer.Utils.Interfaces;
using PresentationLayer.MVVM.Base;
using PresentationLayer.MVVM.Models;
using PresentationLayer.Utils.Interfaces;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using static ServiceLayer.DelegateTypes.CustomDelegate;

namespace PresentationLayer.MVVM.ViewModels
{
    public class AllServerUsersViewModel : NotifyBaseViewModel, IAllServerUsersViewModel
    {
        #region Private Attributes
        private IServerManager _serverManager;
        private IClientAction _clientAction;



        private ObservableCollection<ClientUserModel> _itemsSourceAllUsers;
        private ClientUserModel _selectedItemUser;


        #endregion Private Attributes 


        #region Public Properties 
        public ObservableCollection<ClientUserModel> ItemsSourceAllUsers
        {
            get { return _itemsSourceAllUsers; }
            set { _itemsSourceAllUsers = value;
                OnPropertyChanged(nameof(ItemsSourceAllUsers));}        
        }

        public ClientUserModel SelectedItemUser
        {
            get { return _selectedItemUser; }
            set { _selectedItemUser = value;
            OnPropertyChanged(nameof(SelectedItemUser));}
        }
                

        #endregion Public Properties 


        #region Commands 

        #endregion Commands
        public AllServerUsersViewModel(IServerManager serverManager, IClientAction clientAction)
        {
            _serverManager = serverManager;
            _clientAction = clientAction;

        ConnectedClentsListDelegate ConnectedClientsListCallback = new ConnectedClentsListDelegate(ConnectedClientsListReportCallback);
            _serverManager.SetConnectedClientsListCallback(ConnectedClientsListCallback);
            _clientAction.SetConnectedClientsListCallback(ConnectedClientsListCallback);
        }

        #region Callbacks
        private void ConnectedClientsListReportCallback(List<ClientInfo> allConnectedClients)
        {
            Application.Current.Dispatcher?.Invoke(delegate () {
                ObservableCollection<ClientUserModel> newList = new ObservableCollection<ClientUserModel>();

                foreach (ClientInfo client in allConnectedClients)
                {
                    var clientUserModel = new ClientUserModel()
                    {
                        UserId = (Guid)client.ServerUserID,
                        Username = client.Username,
                        IsConnected = client.TcpClientInfo.Connected,
                        LocalEndpoint = client.TcpClientInfo.Client?.LocalEndPoint?.ToString(),
                        RemoteEndPoint = client.TcpClientInfo.Client?.RemoteEndPoint?.ToString()

                    };
                    
                    newList.Add(clientUserModel);
                }
                ItemsSourceAllUsers = newList;

            });

        }


        #endregion Callbacks
    }
}
