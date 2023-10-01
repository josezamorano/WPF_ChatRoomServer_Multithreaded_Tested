using DomainLayer.Utils.Interfaces;
using PresentationLayer.MVVM.Base;
using PresentationLayer.Utils.Interfaces;
using ServiceLayer.Constants;
using ServiceLayer.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using static ServiceLayer.DelegateTypes.CustomDelegate;

namespace PresentationLayer.MVVM.ViewModels
{
    public class AllChatRoomsViewModel : NotifyBaseViewModel,  IAllChatRoomsViewModel
    {
        #region Private Attributes
        private IChatRoomObserver _chatRoomObserver;
        private IChatRoomManager _chatRoomManager;

        private string _gridAllChatRoomsVisibility;
        private ObservableCollection<ChatRoom> _itemsSourceAllChatRooms;
        private ChatRoom _selectedItemChatRoom;

        private ChatRoom _currentChatRoomSelectedOnDisplay;

        #endregion Private Attributes 


        #region Public Properties 

        public string GridAllChatRoomsVisibility
        {
            get { return _gridAllChatRoomsVisibility;}
            set {  _gridAllChatRoomsVisibility = value;
            OnPropertyChanged(nameof(GridAllChatRoomsVisibility));  }
        }

        public ObservableCollection<ChatRoom> ItemsSourceAllChatRooms
        {
            get { return _itemsSourceAllChatRooms; }
            set {  _itemsSourceAllChatRooms = value;
                OnPropertyChanged(nameof(ItemsSourceAllChatRooms)); }
        }

        public ChatRoom SelectedItemChatRoom
        {
            get { return _selectedItemChatRoom; }
            set { _selectedItemChatRoom = value;
                OnChatRoomSelectedEvent(value);
                OnPropertyChanged(nameof(SelectedItemChatRoom)); }
        }



        #endregion Public Properties 

        #region Commands

        #endregion Commands


        public AllChatRoomsViewModel(IChatRoomObserver chatRoomObserver, IChatRoomManager chatRoomManager)
        {

            _chatRoomObserver = chatRoomObserver;
            _chatRoomManager = chatRoomManager;
            GridAllChatRoomsVisibility = CustomConstant.COLLAPSED;

            _itemsSourceAllChatRooms = new ObservableCollection<ChatRoom>();

            ChatRoomsUpdateDelegate allChatRoomsUpdateCallback = new ChatRoomsUpdateDelegate(AllChatRoomsUpdate_ThreadCallback);
            _chatRoomManager.SetAllChatRoomsUpdateCallback(allChatRoomsUpdateCallback);

            SingleChatRoomUpdateDelegate singleChatRoomUpdateCallback = new SingleChatRoomUpdateDelegate(SingleChatRoomUpdate_ThreadCallback);
            _chatRoomManager.SetSingleChatRoomUpdateCallback(singleChatRoomUpdateCallback);

            AllChatRoomsRemovedOnServerStoppingDelegate allChatRoomsRemovedOnServerStoppingCallback = 
                new AllChatRoomsRemovedOnServerStoppingDelegate(AllChatRoomsRemovedOnServerStopping_ThreadCallback);
            _chatRoomManager.SetAllChatRoomsRemovedOnServerStoppingCallback(allChatRoomsRemovedOnServerStoppingCallback);

        }

        #region Callbacks

        private void SingleChatRoomUpdate_ThreadCallback(ChatRoom singleChatRoom)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                ObservableCollection<ChatRoom> newList = new ObservableCollection<ChatRoom>();
                newList = ItemsSourceAllChatRooms;

                var chatRoomForUpdate = newList.Where(a=>a.ChatRoomId == singleChatRoom.ChatRoomId).FirstOrDefault();
                if(chatRoomForUpdate != null)
                {
                    newList.Remove(chatRoomForUpdate);
                    newList.Add(singleChatRoom);
                }

                ItemsSourceAllChatRooms = newList;
            });

            if (SelectedItemChatRoom != null && SelectedItemChatRoom.ChatRoomId == singleChatRoom.ChatRoomId)
            {
                OnChatRoomSelectedEvent(singleChatRoom);
            }
        }
        private void AllChatRoomsUpdate_ThreadCallback(List<ChatRoom> allChatRooms)
        {
            Application.Current.Dispatcher.Invoke(() => 
            { 
                ObservableCollection<ChatRoom> newList = new ObservableCollection<ChatRoom>();
                foreach(var chatRoom in allChatRooms)
                {
                    chatRoom.AllActiveUsersInChatRoomCount = chatRoom.AllActiveUsersInChatRoom.Count;
                    newList.Add(chatRoom);
                }

                ItemsSourceAllChatRooms = newList;
                if(allChatRooms.Count == 0)
                {
                    _chatRoomObserver.NotifySelectedChatRoomDisplay(null);
                }
            });
        }

        private void AllChatRoomsRemovedOnServerStopping_ThreadCallback(List<ChatRoom> allChatRooms)
        {
            if(allChatRooms.Count == 0)
            {
                ItemsSourceAllChatRooms.Clear();
            }

            if(SelectedItemChatRoom != null)
            {
                _chatRoomObserver.NotifyServerStoppingAndRemoveSingleChatRoom(null);
            }
            
        }

        #endregion Callbacks

        #region Events 
        private void OnChatRoomSelectedEvent(ChatRoom chatRoom)
        {
            _currentChatRoomSelectedOnDisplay = chatRoom;
            if (chatRoom != null)
            {              
                _chatRoomObserver.NotifySelectedChatRoomDisplay(chatRoom);
            }
        }

        #endregion Events 
    }
}
