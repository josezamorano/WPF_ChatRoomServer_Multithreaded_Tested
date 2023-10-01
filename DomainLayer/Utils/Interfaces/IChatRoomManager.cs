using ServiceLayer.Enumerations;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using static ServiceLayer.DelegateTypes.CustomDelegate;

namespace DomainLayer.Utils.Interfaces
{

    public interface IChatRoomManager
    {
        void SetAllChatRoomsUpdateCallback(ChatRoomsUpdateDelegate chatRoomUpdateCallback);

        void SetSingleChatRoomUpdateCallback(SingleChatRoomUpdateDelegate singleChatRoomUpdateCallback);

        void SetAllChatRoomsRemovedOnServerStoppingCallback(AllChatRoomsRemovedOnServerStoppingDelegate allChatRoomsRemovedOnServerStoppingCallback);

        ChatRoom CreateChatRoom(ChatRoom chatRoomFromServerUser);

        void AddChatRoomToAllChatRooms(ChatRoom chatRoom);

        List<ChatRoom> GetAllCreatedChatRooms();

        void RemoveAllChatRooms();

        void RemoveAllChatRoomsOnServerStopping();

        bool UpdateChatRoomStatus(Guid chatRoomId, ChatRoomStatus chatRoomStatus);

        bool UpdateInvitedGuestServerUserInChatRoom(Guid chatRoomId, InviteStatus inviteStatus, ServerUser serverUser);

        bool RemoveUserFromAllActiveUsersInChatRoom(Guid targetChatRoomId, Guid serverUserId);

        bool RemoveUserFromAllChatRooms(Guid serverUserId);

        bool RecordMessageInChatRoomConversation(Guid chatRoomId, string message);
    }
}
