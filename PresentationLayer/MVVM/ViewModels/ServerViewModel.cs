using DomainLayer.Models;
using DomainLayer.Utils.Interfaces;
using PresentationLayer.MVVM.Base;
using PresentationLayer.Utils.Interfaces;
using ServiceLayer.Constants;
using ServiceLayer.Enumerations;
using ServiceLayer.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using static ServiceLayer.DelegateTypes.CustomDelegate;

namespace PresentationLayer.MVVM.ViewModels
{
    public class ServerViewModel : NotifyBaseViewModel, IServerViewModel
    {
        #region Private Attributes
        private IInputValidator _inputValidator;
        private IServerManager _serverManager;

        private string _serverRunning;
        private string _serverStopped;


        private string _serverStatus;
        private string _serverStatusColor;
        private string _connectedClientsCount;
        private string _serverIPAddress;
        private string _listenOnPortNumber;
        private string _serverWarning;
        private string _serverLogReport;

        private bool _buttonStartServerIsEnabled;
        private bool _buttonStopServerIsEnabled;


        #endregion Private Attributes

        #region Public Properties
        public string ServerStatus
        {
            get { return _serverStatus; }
            set { _serverStatus = value;
                OnPropertyChanged(nameof(ServerStatus)); }
        }

        public string ServerStatusColor
        {
            get { return _serverStatusColor; }
            set { _serverStatusColor = value;
                OnPropertyChanged(nameof(ServerStatusColor)); }
        }

        public string ConnectedClientsCount
        {
            get { return _connectedClientsCount; }
            set { _connectedClientsCount = value;
                OnPropertyChanged(nameof(ConnectedClientsCount)); }
        }

        public string ServerIPAddress
        {
            get { return _serverIPAddress; }
            set { _serverIPAddress = value;
                OnPropertyChanged(nameof(ServerIPAddress)); }
        }

        public string ListenOnPortNumber
        {
            get { return _listenOnPortNumber; }
            set { _listenOnPortNumber = value;
                ClearServerWarning();
                _listenOnPortNumber = FilterTextAcceptOnlyDigits(value);
                OnPropertyChanged(nameof(ListenOnPortNumber)); }
        }

        public string ServerWarning
        {
            get { return _serverWarning; }
            set { _serverWarning = value;
                OnPropertyChanged(nameof(ServerWarning)); }
        }

        public string ServerLogReport
        {
            get { return _serverLogReport; }
            set { _serverLogReport = value;
                OnPropertyChanged(nameof(ServerLogReport)); }
        }

        public bool ButtonStartServerIsEnabled
        {
            get { return _buttonStartServerIsEnabled; }
            set { _buttonStartServerIsEnabled = value;
                OnPropertyChanged(nameof(ButtonStartServerIsEnabled)); }
        }

        public bool ButtonStopServerIsEnabled
        {
            get { return _buttonStopServerIsEnabled; } 
            set { _buttonStopServerIsEnabled = value; 
                OnPropertyChanged(nameof(ButtonStopServerIsEnabled));}
        }


        #endregion Public Properties


        #region Commands
        public ICommand ButtonStartServerCommand { get; set; }
        public ICommand ButtonStopServerCommand { get; set; }

        #endregion Commands

        public ServerViewModel(IInputValidator inputValidator,IServerManager serverManager)
        {
            _inputValidator = inputValidator;
            _serverManager = serverManager;

            ServerIPAddress = _serverManager.GetLocalIP();

            _serverRunning = Enum.GetName(typeof(ServerStatus), ServiceLayer.Enumerations.ServerStatus.Running);
            _serverStopped = Enum.GetName(typeof(ServerStatus), ServiceLayer.Enumerations.ServerStatus.Stopped);


            ServerStatus = _serverStopped;
            ServerStatusColor = CustomConstant.STRING_PLAINTEXT_FLUO_LIGHTBLUE;
            ConnectedClientsCount = CustomConstant.ZERO_NUMBER;

            ListenOnPortNumber = string.Empty;
            ServerWarning = string.Empty;

            ButtonStartServerIsEnabled = true;
            ButtonStopServerIsEnabled = false;

            ButtonStartServerCommand = new CommandBaseViewModel(ExecuteButtonStartServerCommand);
            ButtonStopServerCommand = new CommandBaseViewModel(ExecuteButtonStopServerCommand);
            
        }


        #region Execute Command
        private void ExecuteButtonStartServerCommand(object obj)
        {
            ClearServerWarning();

            if (!ResolveValidation()) return;
            ServerActivityInfo serverActivityInfo = CreateServerActivityInfo();
            _serverManager.StartServer(serverActivityInfo);
        }

        private void ExecuteButtonStopServerCommand(object obj)
        {
            ClearServerWarning();
            ServerActivityInfo serverActivityInfo = CreateServerActivityInfo();
            _serverManager.StopServer(serverActivityInfo);
        }

        #endregion Execute Command


        #region Callbacks
        private void ServerLoggerReportCallback(string report)
        {
            Thread threadReport = new Thread(delegate () 
            {
                ServerLogReport += report;
                ServerLogReport += Environment.NewLine;

            });
            threadReport.IsBackground = true;
            threadReport.Name = "threadReport";
            threadReport.Start();
        }

        private void ServerStatusReportCallback(bool isActive)
        {
            Thread threadServerStatus = new Thread(delegate () 
            {
                ServerStatus = (isActive) ? _serverRunning : _serverStopped;
                ServerStatusColor = (isActive) ? CustomConstant.STRING_PLAINTEXT_FLUO_LIGHTBLUE : CustomConstant.STRING_PLAINTEXT_FLUO_RED;
                ButtonStartServerIsEnabled = (isActive) ? false : true;
                ButtonStopServerIsEnabled = (isActive) ? true : false;

            });
            threadServerStatus.IsBackground = true;
            threadServerStatus.Name = "threadServerStatus";
            threadServerStatus.Start();
        }

        private void ConnectedClientsCountReportCallback(int activeClientsCount)
        {
            Thread threadClientsCount = new Thread(delegate () 
            {
                ConnectedClientsCount = activeClientsCount.ToString();

            });
            threadClientsCount.IsBackground = true;
            threadClientsCount.Name = "threadClientsCount";
            threadClientsCount.Start();
        }

       
        #endregion Callbacks


        #region Helper Methods

        private void ClearServerWarning()
        {
            ServerWarning = string.Empty;
        }
        private string FilterTextAcceptOnlyDigits(string text)
        {
            var filteredText = string.Concat(text.Where(char.IsDigit));
            return filteredText;
        }

        private bool ResolveValidation()
        {
            string report = _inputValidator.ValidateServerInputs(ListenOnPortNumber);
            if (!string.IsNullOrEmpty(report))
            {
                ServerWarning = report;
                return false;
            }
            return true;
        }

        private ServerActivityInfo CreateServerActivityInfo()
        {

            ServerActivityInfo serverActivityInfo = new ServerActivityInfo()
            {
                Port = Int32.Parse(ListenOnPortNumber),
                ServerLoggerCallback = new ServerLoggerDelegate(ServerLoggerReportCallback),
                ServerStatusCallback = new ServerStatusDelegate(ServerStatusReportCallback),
                ConnectedClientsCountCallback = new ConnectedClientsCountDelegate(ConnectedClientsCountReportCallback),
               
            };

            return serverActivityInfo;
        }

        #endregion Helper Methods
    }
}
