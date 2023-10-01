using PresentationLayer.Utils.Interfaces;
using ServiceLayer.Models;
using System;

namespace PresentationLayer.EventObservers
{
    public class ChatRoomObserver : IChatRoomObserver
    {

        public event Action<ChatRoom> OnChatRoomDisplayEvent;

        public event Action<ChatRoom> OnServerStoppingRemoveChatRoomEvent;

        public void NotifySelectedChatRoomDisplay(ChatRoom chatRoom)
        {
            OnChatRoomDisplayEvent?.Invoke(chatRoom);
        }

        public void NotifyServerStoppingAndRemoveSingleChatRoom(ChatRoom chatRoom)
        {
            OnServerStoppingRemoveChatRoomEvent?.Invoke(chatRoom);  
        }
    }
}
