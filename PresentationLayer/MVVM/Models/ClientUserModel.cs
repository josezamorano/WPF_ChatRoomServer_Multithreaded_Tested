using System;

namespace PresentationLayer.MVVM.Models
{
    public class ClientUserModel
    {
        public Guid? UserId { get; set; }
        public string Username { get; set; }

        public bool? IsConnected { get; set; }

        public string LocalEndpoint { get; set; }

        public string RemoteEndPoint{ get; set; }
    }
}
