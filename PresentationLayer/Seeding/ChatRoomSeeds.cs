using PresentationLayer.MVVM.ViewModels;
using ServiceLayer.Enumerations;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PresentationLayer.Seeding
{
    public static class ChatRoomSeeds
    {
        //NOTE: Copy and paste this command in the constructor of the file:
        //AllChatRoomsViewModel.cs to seed the views with ChatRooms
        //============
        //var allItems = ChatRoomSeeds.GetAllChatRoomSeeds();
        //foreach(var item in allItems)
        //{
        //    item.AllActiveUsersInChatRoomCount = item.AllActiveUsersInChatRoom.Count;
        //    ItemsSourceAllChatRooms.Add(item);
        //}
        //ItemsSourceAllChatRooms = allItems;
        //=================


        public static ObservableCollection<ChatRoom> GetAllChatRoomSeeds()
        {
            ObservableCollection<ChatRoom> newList = new ObservableCollection<ChatRoom>(); 
            List<ChatRoom> chatRooms = GetAllChatRooms();
            foreach(ChatRoom chatRoom in chatRooms)
            {
                newList.Add(chatRoom);  
            }

            return newList; ;
        }

        private static List<ChatRoom> GetAllChatRooms()
        {
            List<ChatRoom> allChatRooms = new List<ChatRoom>();
            ChatRoom chatRoom1 = new ChatRoom()
            {
                ChatRoomId = Guid.NewGuid(),
                ChatRoomName = "abc",
                ChatRoomIdentifierNameId = "abc-111",
                ChatRoomStatus = ChatRoomStatus.OpenActive,
                AllActiveUsersInChatRoom = new List<ServerUser> { new ServerUser() { Username = "abc" }, new ServerUser() { Username = "mno" }, new ServerUser() { Username = "Jonathan" }, new ServerUser() { Username = "Surex" } },
                AllInvitesSentToGuestUsers = new List<Invite> { new Invite() { GuestServerUser = new ServerUser() { Username = "TOM" }, InviteStatus = InviteStatus.Accepted }, }

            };
            ChatRoom chatRoom2 = new ChatRoom()
            {
                ChatRoomId = Guid.NewGuid(),
                ChatRoomName = "abc",
                ChatRoomIdentifierNameId = "abc-111",
                ChatRoomStatus = ChatRoomStatus.OpenActive,
                AllActiveUsersInChatRoom = new List<ServerUser> { new ServerUser() { Username = "abc1" }, new ServerUser() { Username = "mno" } },
                AllInvitesSentToGuestUsers = new List<Invite> { new Invite() { GuestServerUser = new ServerUser() { Username = "Mark" }, InviteStatus = InviteStatus.SentAndPendingResponse } }

            };
            ChatRoom chatRoom3 = new ChatRoom()
            {
                ChatRoomId = Guid.NewGuid(),
                ChatRoomName = "abc",
                ChatRoomIdentifierNameId = "abc-111",
                ChatRoomStatus = ChatRoomStatus.OpenActive,
                AllActiveUsersInChatRoom = new List<ServerUser> { new ServerUser() { Username = "abc2" }, new ServerUser() { Username = "mno" } },
                AllInvitesSentToGuestUsers = new List<Invite> { new Invite() { GuestServerUser = new ServerUser() { Username = "Pam" }, InviteStatus = InviteStatus.SentAndPendingResponse }, }

            };
            ChatRoom chatRoom4 = new ChatRoom()
            {
                ChatRoomId = Guid.NewGuid(),
                ChatRoomName = "abc",
                ChatRoomIdentifierNameId = "abc-111",
                ChatRoomStatus = ChatRoomStatus.OpenActive,
                AllActiveUsersInChatRoom = new List<ServerUser> { new ServerUser() { Username = "abc3" }, new ServerUser() { Username = "mno" } },
                AllInvitesSentToGuestUsers = new List<Invite> { new Invite() { GuestServerUser = new ServerUser() { Username = "Jack" }, InviteStatus = InviteStatus.SentAndPendingResponse }, }

            };
            ChatRoom chatRoom5 = new ChatRoom()
            {
                ChatRoomIdentifierNameId = "abc-111",
                ChatRoomStatus = ChatRoomStatus.OpenActive,
                AllActiveUsersInChatRoom = new List<ServerUser> { new ServerUser() { Username = "abc3" }, new ServerUser() { Username = "mno" } },
                AllInvitesSentToGuestUsers = new List<Invite> { new Invite() { GuestServerUser = new ServerUser() { Username = "Jack" }, InviteStatus = InviteStatus.SentAndPendingResponse }, }

            };
            ChatRoom chatRoom6 = new ChatRoom()
            {
                ChatRoomIdentifierNameId = "abc-111",
                ChatRoomStatus = ChatRoomStatus.OpenActive,
                AllActiveUsersInChatRoom = new List<ServerUser> { new ServerUser() { Username = "abc3" }, new ServerUser() { Username = "mno" } },
                AllInvitesSentToGuestUsers = new List<Invite> { new Invite() { GuestServerUser = new ServerUser() { Username = "Jack" }, InviteStatus = InviteStatus.SentAndPendingResponse }, }

            };
            ChatRoom chatRoom7 = new ChatRoom()
            {
                ChatRoomIdentifierNameId = "abc-111",
                ChatRoomStatus = ChatRoomStatus.OpenActive,
                AllActiveUsersInChatRoom = new List<ServerUser> { new ServerUser() { Username = "abc3" }, new ServerUser() { Username = "mno" } },
                AllInvitesSentToGuestUsers = new List<Invite> { new Invite() { GuestServerUser = new ServerUser() { Username = "Jack" }, InviteStatus = InviteStatus.SentAndPendingResponse }, }

            };
            ChatRoom chatRoom8 = new ChatRoom()
            {
                
                ChatRoomIdentifierNameId = "abc-111",
                ChatRoomStatus = ChatRoomStatus.OpenActive,
                AllActiveUsersInChatRoom = new List<ServerUser> { new ServerUser() { Username = "abc3" }, new ServerUser() { Username = "mno" } },
                AllInvitesSentToGuestUsers = new List<Invite> { new Invite() { GuestServerUser = new ServerUser() { Username = "Jack" }, InviteStatus = InviteStatus.SentAndPendingResponse }, }

            };
            ChatRoom chatRoom9 = new ChatRoom()
            {
                ChatRoomIdentifierNameId = "abc-111",
                ChatRoomStatus = ChatRoomStatus.OpenActive,
                AllActiveUsersInChatRoom = new List<ServerUser> { new ServerUser() { Username = "abc3" }, new ServerUser() { Username = "mno" } },
                AllInvitesSentToGuestUsers = new List<Invite> { new Invite() { GuestServerUser = new ServerUser() { Username = "Jack" }, InviteStatus = InviteStatus.SentAndPendingResponse }, }

            };
            ChatRoom chatRoom10 = new ChatRoom()
            {
                ChatRoomIdentifierNameId = "abc-111",
                ChatRoomStatus = ChatRoomStatus.OpenActive,
                AllActiveUsersInChatRoom = new List<ServerUser> { new ServerUser() { Username = "abc3" }, new ServerUser() { Username = "mno" } },
                AllInvitesSentToGuestUsers = new List<Invite> { new Invite() { GuestServerUser = new ServerUser() { Username = "Jack" }, InviteStatus = InviteStatus.SentAndPendingResponse }, }

            };
            ChatRoom chatRoom11 = new ChatRoom()
            {
                ChatRoomIdentifierNameId = "abc-111",
                ChatRoomStatus = ChatRoomStatus.OpenActive,
                AllActiveUsersInChatRoom = new List<ServerUser> { new ServerUser() { Username = "abc3" }, new ServerUser() { Username = "mno" } },
                AllInvitesSentToGuestUsers = new List<Invite> { new Invite() { GuestServerUser = new ServerUser() { Username = "Jack" }, InviteStatus = InviteStatus.SentAndPendingResponse }, }

            }; ChatRoom chatRoom12 = new ChatRoom()
            {
                ChatRoomIdentifierNameId = "abc-111",
                ChatRoomStatus = ChatRoomStatus.OpenActive,
                AllActiveUsersInChatRoom = new List<ServerUser> { new ServerUser() { Username = "abc3" }, new ServerUser() { Username = "mno" } },
                AllInvitesSentToGuestUsers = new List<Invite> { new Invite() { GuestServerUser = new ServerUser() { Username = "Jack" }, InviteStatus = InviteStatus.SentAndPendingResponse }, }

            }; ChatRoom chatRoom13 = new ChatRoom()
            {
                ChatRoomIdentifierNameId = "abc-111",
                ChatRoomStatus = ChatRoomStatus.OpenActive,
                AllActiveUsersInChatRoom = new List<ServerUser> { new ServerUser() { Username = "abc3" }, new ServerUser() { Username = "mno" } },
                AllInvitesSentToGuestUsers = new List<Invite> { new Invite() { GuestServerUser = new ServerUser() { Username = "Jack" }, InviteStatus = InviteStatus.SentAndPendingResponse }, }

            }; ChatRoom chatRoom14 = new ChatRoom()
            {
                ChatRoomIdentifierNameId = "abc-111",
                ChatRoomStatus = ChatRoomStatus.OpenActive,
                AllActiveUsersInChatRoom = new List<ServerUser> { new ServerUser() { Username = "abc3" }, new ServerUser() { Username = "mno" } },
                AllInvitesSentToGuestUsers = new List<Invite> { new Invite() { GuestServerUser = new ServerUser() { Username = "Jack" }, InviteStatus = InviteStatus.SentAndPendingResponse }, }

            };




            allChatRooms.Add(chatRoom1);
            allChatRooms.Add(chatRoom2);
            allChatRooms.Add(chatRoom3);
            allChatRooms.Add(chatRoom4);
            allChatRooms.Add(chatRoom5);
            allChatRooms.Add(chatRoom6);
            allChatRooms.Add(chatRoom7); 
            allChatRooms.Add(chatRoom8); 
            allChatRooms.Add(chatRoom9);
            allChatRooms.Add(chatRoom10);
            allChatRooms.Add(chatRoom11);
            allChatRooms.Add(chatRoom12);
            allChatRooms.Add(chatRoom13);
            allChatRooms.Add(chatRoom14); 
            return allChatRooms;
        }

    }
}
