using ServiceLayer.Models;
using System.Collections.Generic;

namespace ServiceLayer.DelegateTypes
{
    public class CustomDelegate
    {
        public delegate void ServerLoggerDelegate(string serverStatusLog);

        public delegate void ServerStatusDelegate(bool status);
        
        public delegate void ConnectedClientsCountDelegate(int activeClientsCount);
        
        public delegate void ConnectedClentsListDelegate(List<ClientInfo> allClients);
        
        public delegate void ChatRoomsUpdateDelegate(List<ChatRoom> allChatRooms);

        public delegate void SingleChatRoomUpdateDelegate(ChatRoom singleChatRoom);

        public delegate void MessageFromClientDelegate(string messageFromClient);

        public delegate void AllChatRoomsRemovedOnServerStoppingDelegate(List<ChatRoom> allChatRooms);
    }
}
