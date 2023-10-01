using ServiceLayer.Enumerations;
using System;
using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public class Payload
    {
        public MessageActionType MessageActionType { get; set; }

        public string ClientUsername { get; set; }

        public Guid? UserId { get; set; }

        public List<ServerUser> ActiveServerUsers { get; set; }

        public ChatRoom ChatRoomCreated { get; set; }

        public Invite InviteToGuestUser { get; set; }

        public string MessageToChatRoom { get; set; }

        public ServerUser ServerUserDisconnected { get; set; }

        public ServerUser ServerUserRemovedFromChatRoom { get; set; }
    }
}
