using PresentationLayer.MVVM.Base;
using PresentationLayer.Utils.Interfaces;
using ServiceLayer.Constants;
using ServiceLayer.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PresentationLayer.MVVM.ViewModels
{
    public class SingleChatRoomViewModel :NotifyBaseViewModel, ISingleChatRoomViewModel
    {
        #region Private Attributes 
        IChatRoomObserver _chatRoomObserver;


        private string _gridSingleChatRoomVisibility;

        private string _singleChatRoomTitleColor;
        private string _singleChatRoomDescription;
        private string _singleChatRoomDescriptionColor;
        


        private Guid? _singleChatRoomID;
        private ObservableCollection<string> _singleChatRoomAllActiveUsers;
        private double _singleChatRoomAllActiveUsersCount;
        private ObservableCollection<string> _singleChatRoomAllInvitesSentStatus;
        private double _singleChatRoomAllInvitesSentCount;

        private string _singleChatRoomConversationRecord;






        #endregion Private Attributes 


        #region Public Properties 
        public string GridSingleChatRoomVisibility
        {
            get { return _gridSingleChatRoomVisibility; }
            set { _gridSingleChatRoomVisibility = value;
                OnPropertyChanged(nameof(GridSingleChatRoomVisibility));
            }
        }

        public string SingleChatRoomTitleColor
        {
            get { return _singleChatRoomTitleColor; }
            set { _singleChatRoomTitleColor = value;
                OnPropertyChanged(nameof(SingleChatRoomTitleColor)); }
        }

        public string SingleChatRoomDescription
        {
            get { return _singleChatRoomDescription; }
            set { _singleChatRoomDescription = value;
                OnPropertyChanged(nameof(SingleChatRoomDescription)); }
        }


        public string SingleChatRoomDescriptionColor
        {
            get { return _singleChatRoomDescriptionColor; }
            set { _singleChatRoomDescriptionColor = value;
                OnPropertyChanged(nameof(SingleChatRoomDescriptionColor)); }
        }

        public Guid? SingleChatRoomID
        {
            get { return _singleChatRoomID; }
            set { _singleChatRoomID = value;
            OnPropertyChanged(nameof(SingleChatRoomID)); }
        }

        public ObservableCollection<string> SingleChatRoomAllActiveUsers
        {
            get { return _singleChatRoomAllActiveUsers; }
            set { _singleChatRoomAllActiveUsers = value;
                OnPropertyChanged(nameof(SingleChatRoomAllActiveUsers)); }
        }

        public double SingleChatRoomAllActiveUsersCount
        {
            get { return _singleChatRoomAllActiveUsersCount; }
            set { _singleChatRoomAllActiveUsersCount = value;
                OnPropertyChanged(nameof(SingleChatRoomAllActiveUsersCount)); }
        }

        public string SingleChatRoomConversationRecord
        {
            get { return _singleChatRoomConversationRecord; }
            set { _singleChatRoomConversationRecord = value;
                OnPropertyChanged(nameof(SingleChatRoomConversationRecord));}
        }

        public ObservableCollection<string> SingleChatRoomAllInvitesSentStatus
        {
            get { return _singleChatRoomAllInvitesSentStatus; }
            set { _singleChatRoomAllInvitesSentStatus = value;
                OnPropertyChanged(nameof(SingleChatRoomAllInvitesSentStatus)); }
        }

        public double SingleChatRoomAllInvitesSentCount
        {
            get { return _singleChatRoomAllInvitesSentCount; }
            set { _singleChatRoomAllInvitesSentCount = value;
                OnPropertyChanged(nameof(SingleChatRoomAllInvitesSentCount));
            }
        }


        #endregion Public Properties


        #region Commands

        public ICommand ButtonSingleChatRoomGoBackCommand { get; set; }

        #endregion Commands

        public SingleChatRoomViewModel(IChatRoomObserver chatRoomObserver)
        {
            _chatRoomObserver = chatRoomObserver;
            _singleChatRoomAllActiveUsers = new ObservableCollection<string>();
            _singleChatRoomAllInvitesSentStatus = new ObservableCollection<string>();



            SingleChatRoomTitleColor = CustomConstant.STRING_PLAINTEXT_FLUO_LIGHTBLUE;
            SingleChatRoomDescriptionColor = CustomConstant.STRING_PLAINTEXT_NEONWHITE;

            _chatRoomObserver.OnChatRoomDisplayEvent += ExecuteOnChatRoomDisplayEventHandler;
            _chatRoomObserver.OnServerStoppingRemoveChatRoomEvent += _chatRoomObserver_OnServerStoppingRemoveChatRoomEvent;

        }

        private void _chatRoomObserver_OnServerStoppingRemoveChatRoomEvent(ChatRoom obj)
        {
            ResolveChatRoomDisplay(null);
        }



        #region Event Handlers 

        private void ExecuteOnChatRoomDisplayEventHandler(ChatRoom? chatRoom)
        {
            ResolveChatRoomDisplay(chatRoom);
        }
        private void ResolveChatRoomDisplay(ChatRoom? chatRoom)
        {
            Application.Current.Dispatcher?.Invoke(delegate () 
            {
                SingleChatRoomDescription =(chatRoom !=null)? chatRoom.ChatRoomName : string.Empty;
                SingleChatRoomID = (chatRoom != null) ? chatRoom.ChatRoomId : null;

                SingleChatRoomAllActiveUsers.Clear();
                if((chatRoom != null))
                {
                    foreach (var user in chatRoom.AllActiveUsersInChatRoom)
                    {
                        SingleChatRoomAllActiveUsers.Add(user.Username);
                    }
                }                    

                SingleChatRoomAllInvitesSentStatus.Clear();
                if(chatRoom != null)
                {
                    foreach (var invite in chatRoom.AllInvitesSentToGuestUsers)
                    {
                        var inviteStatus = invite.GuestServerUser.Username + "_" + invite.InviteStatus;
                        SingleChatRoomAllInvitesSentStatus.Add(inviteStatus);
                    }
                }
                SingleChatRoomConversationRecord = (chatRoom != null) ? chatRoom.ConversationRecord : string.Empty;

                SingleChatRoomAllActiveUsersCount = (chatRoom != null) ? SingleChatRoomAllActiveUsers.Count : 0;
                SingleChatRoomAllInvitesSentCount = (chatRoom != null) ? SingleChatRoomAllInvitesSentStatus.Count : 0;
               
            });
        }

        #endregion Event Handlers
    }
}
