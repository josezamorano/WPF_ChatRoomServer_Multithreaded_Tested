using ServiceLayer.Enumerations;
using System;

namespace ServiceLayer.Models
{
    public class Invite
    {
        public Guid InviteId { get; set; }

        public ServerUser ChatRoomCreator { get; set; }

        public ServerUser GuestServerUser { get; set; }

        public string ChatRoomName { get; set; }

        public Guid ChatRoomId { get; set; }

        public InviteStatus InviteStatus { get; set; }

    }
}
