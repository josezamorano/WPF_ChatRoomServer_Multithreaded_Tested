using ServiceLayer.Models;
using System;

namespace PresentationLayer.Utils.Interfaces
{
    public interface IChatRoomObserver
    {
        event Action<ChatRoom> OnChatRoomDisplayEvent;

        event Action<ChatRoom> OnServerStoppingRemoveChatRoomEvent;
        void NotifySelectedChatRoomDisplay(ChatRoom chatRoom);

        void NotifyServerStoppingAndRemoveSingleChatRoom(ChatRoom chatRoom);
    }
}
