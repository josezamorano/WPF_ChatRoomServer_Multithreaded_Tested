using PresentationLayer.MVVM.Base;
using PresentationLayer.Utils.Interfaces;
using ServiceLayer.Constants;
using ServiceLayer.Models;
using System.Windows.Input;

namespace PresentationLayer.MVVM.ViewModels
{
    public class MainWindowViewModel :NotifyBaseViewModel,  IMainWindowViewModel
    {
        IChatRoomObserver _chatRoomObserver;

        ISingleChatRoomViewModel _singleChatRoomViewModel;
        IAllChatRoomsViewModel _allChatRoomsViewModel;
        IAllServerUsersViewModel _allServerUsersViewModel;
        IServerViewModel _serverViewModel;

        #region Private Attributes 

        private string _gridHeaderMenuPanelButtonsVisibility;
        private NotifyBaseViewModel _currentChildView;
         

        #endregion private Attributes 


        #region Public Properties 

        public string GridHeaderMenuPanelButtonsVisibility
        {
            get { return _gridHeaderMenuPanelButtonsVisibility;}
            set {  _gridHeaderMenuPanelButtonsVisibility = value;
                OnPropertyChanged(nameof(GridHeaderMenuPanelButtonsVisibility)); }
        }

        public NotifyBaseViewModel CurrentChildView
        {
            get { return _currentChildView; }
            set { _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView)); }
        }


        #endregion Public Properties 


        #region Commands 
        public ICommand OpenServerViewCommand { get; set; }
        public ICommand OpenAllChatRoomsViewCommand { get; set; }   
        public ICommand OpenAllServerUserstViewCommand { get; set; }    

        #endregion Commands 

        public MainWindowViewModel(
                                   IChatRoomObserver chatRoomObserver,
                                   ISingleChatRoomViewModel singleChatRoomViewModel,
                                   IAllChatRoomsViewModel allChatRoomsViewModel, 
                                   IAllServerUsersViewModel allServerUsersViewModel, 
                                   IServerViewModel serverViewModel
            
            )
        {

            _chatRoomObserver = chatRoomObserver;
            _singleChatRoomViewModel = singleChatRoomViewModel;
            _allChatRoomsViewModel = allChatRoomsViewModel;
            _allServerUsersViewModel = allServerUsersViewModel;
            _serverViewModel = serverViewModel;

            GridHeaderMenuPanelButtonsVisibility = CustomConstant.VISIBLE;

            OpenServerViewCommand = new CommandBaseViewModel(ExecuteOpenServerViewCommand);
            OpenAllChatRoomsViewCommand = new CommandBaseViewModel(ExecuteOpenAllChatRoomsViewCommand);
            OpenAllServerUserstViewCommand = new CommandBaseViewModel(ExecuteOpenAllServerUserstViewCommand);
            
            _chatRoomObserver.OnChatRoomDisplayEvent += ExecuteOpenSingleChatRoomEventHandler;
            _singleChatRoomViewModel.ButtonSingleChatRoomGoBackCommand = new CommandBaseViewModel(ExecuteButtonSingleChatRoomGoBackCommand);
        }

        #region Execute Commands
        private void ExecuteOpenServerViewCommand(object parameter) 
        {
            CurrentChildView = (NotifyBaseViewModel)_serverViewModel;
        }

        private void ExecuteOpenAllChatRoomsViewCommand(object parameter)
        {
            _allChatRoomsViewModel.GridAllChatRoomsVisibility = CustomConstant.VISIBLE;
            _singleChatRoomViewModel.GridSingleChatRoomVisibility = CustomConstant.COLLAPSED;
            CurrentChildView = (NotifyBaseViewModel) _allChatRoomsViewModel;
        }

        private void ExecuteOpenAllServerUserstViewCommand(object parameter)
        {
            CurrentChildView =(NotifyBaseViewModel) _allServerUsersViewModel;
        }

        private void ExecuteButtonSingleChatRoomGoBackCommand(object parameter)
        {
            GridHeaderMenuPanelButtonsVisibility = CustomConstant.VISIBLE;
            _allChatRoomsViewModel.GridAllChatRoomsVisibility = CustomConstant.VISIBLE;
            _singleChatRoomViewModel.GridSingleChatRoomVisibility = CustomConstant.COLLAPSED;
            _allChatRoomsViewModel.SelectedItemChatRoom = null;
            CurrentChildView = (NotifyBaseViewModel)_allChatRoomsViewModel;
        }
        #endregion Execute Commands 

        #region Event Handlers 


        private void ExecuteOpenSingleChatRoomEventHandler(ChatRoom parameter)
        {
            ChatRoom chatRoom = parameter;
            GridHeaderMenuPanelButtonsVisibility = CustomConstant.COLLAPSED;
            _allChatRoomsViewModel.GridAllChatRoomsVisibility = CustomConstant.COLLAPSED;
            _singleChatRoomViewModel.GridSingleChatRoomVisibility = CustomConstant.VISIBLE;
            CurrentChildView = (NotifyBaseViewModel)_singleChatRoomViewModel;
        }

        #endregion Event Handlers


        #region Private Methods 

        public override void Dispose()
        {
            _chatRoomObserver.OnChatRoomDisplayEvent -= ExecuteOpenSingleChatRoomEventHandler;
            base.Dispose();
        }

        #endregion Private Methods 
    }
}
