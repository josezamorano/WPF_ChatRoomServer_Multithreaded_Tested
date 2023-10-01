using System;
using System.Net.Sockets;

namespace ServiceLayer.Models
{
    public class ClientInfo
    {
        public TcpClient TcpClientInfo { get; set; }

        public Guid? ServerUserID { get; set; }

        public string Username { get; set; }
    }
}
