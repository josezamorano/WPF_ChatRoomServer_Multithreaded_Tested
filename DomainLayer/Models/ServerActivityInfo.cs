using static ServiceLayer.DelegateTypes.CustomDelegate;

namespace DomainLayer.Models
{
    public class ServerActivityInfo
    {
        public int Port { get; set; }

        public ServerLoggerDelegate ServerLoggerCallback { get; set; }

        public ServerStatusDelegate ServerStatusCallback { get; set; }

        public ConnectedClientsCountDelegate ConnectedClientsCountCallback { get; set; }
    }
}
