﻿using DomainLayer.Utils.Interfaces;
using ServiceLayer.Enumerations;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static ServiceLayer.DelegateTypes.CustomDelegate;

namespace DomainLayer
{
    public class ChatRoomManager : IChatRoomManager
    {
        private const string CRLF = "\r\n";
        private ChatRoomsUpdateDelegate _allChatRoomsUpdateCallback;
        private SingleChatRoomUpdateDelegate _singleChatRoomUpdateCallback;
        private AllChatRoomsRemovedOnServerStoppingDelegate _allChatRoomsRemovedOnServerStoppingCallback;

        private List<ChatRoom> _allCreatedChatRooms;

        IObjectCreator _objectCreator;
        public ChatRoomManager(IObjectCreator objectCreator)
        {
            _allCreatedChatRooms = new List<ChatRoom>();
            _objectCreator = objectCreator;
        }


        #region Properties Setters 
        public void SetAllChatRoomsUpdateCallback(ChatRoomsUpdateDelegate allChatRoomsUpdateCallback)
        {
            _allChatRoomsUpdateCallback = allChatRoomsUpdateCallback;
        }

        public void SetSingleChatRoomUpdateCallback(SingleChatRoomUpdateDelegate singleChatRoomUpdateCallback)
        {
            _singleChatRoomUpdateCallback = singleChatRoomUpdateCallback;
        }

        public void SetAllChatRoomsRemovedOnServerStoppingCallback(AllChatRoomsRemovedOnServerStoppingDelegate allChatRoomsRemovedOnServerStoppingCallback)
        {
            _allChatRoomsRemovedOnServerStoppingCallback = allChatRoomsRemovedOnServerStoppingCallback;
        }

        #endregion Properties Setters 
        public ChatRoom CreateChatRoom(ChatRoom chatRoomFromServerUser)
        {
            ChatRoom chatRoomCreated = _objectCreator.CreateChatRoom(chatRoomFromServerUser.ChatRoomName, chatRoomFromServerUser.Creator, chatRoomFromServerUser.AllActiveUsersInChatRoom, chatRoomFromServerUser.AllInvitesSentToGuestUsers);

            return chatRoomCreated;
        }

        public void AddChatRoomToAllChatRooms(ChatRoom chatRoom)
        {
            var existingChatRoom = _allCreatedChatRooms.Where(a => a.ChatRoomId == chatRoom.ChatRoomId).FirstOrDefault();
            if (existingChatRoom == null)
            {
                _allCreatedChatRooms.Add(chatRoom);

                _allChatRoomsUpdateCallback(_allCreatedChatRooms);
            }
        }

        public List<ChatRoom> GetAllCreatedChatRooms()
        {
            return _allCreatedChatRooms;
        }

        public bool UpdateChatRoomInformation(Guid chatRoomId, ChatRoomStatus chatRoomStatus, Guid inviteId, InviteStatus inviteStatus)
        {
            ChatRoom chatRoomForUpdate = _allCreatedChatRooms.Where(a => a.ChatRoomId == chatRoomId).FirstOrDefault();
            if (chatRoomForUpdate == null) { return false; }

            chatRoomForUpdate.ChatRoomStatus = chatRoomStatus;

            return true;
        }

        public bool UpdateChatRoomStatus(Guid chatRoomId, ChatRoomStatus chatRoomStatus)
        {
            ChatRoom chatRoomForUpdate = _allCreatedChatRooms.Where(a => a.ChatRoomId == chatRoomId).FirstOrDefault();
            if (chatRoomForUpdate != null)
            {
                chatRoomForUpdate.ChatRoomStatus = chatRoomStatus;
                return true;
            }

            return false;
        }

        public void RemoveAllChatRooms()
        {
            _allCreatedChatRooms.Clear();
            if(_allChatRoomsUpdateCallback != null)
            {
                _allChatRoomsUpdateCallback(_allCreatedChatRooms);
            }
            
        }

        public void RemoveAllChatRoomsOnServerStopping()
        {
            _allCreatedChatRooms.Clear();
            if (_allChatRoomsRemovedOnServerStoppingCallback != null)
            {
                _allChatRoomsRemovedOnServerStoppingCallback(_allCreatedChatRooms);
            }

        }

        public bool UpdateInvitedGuestServerUserInChatRoom(Guid chatRoomId, InviteStatus inviteStatus, ServerUser serverUser)
        {
            bool chatRoomIsUpdated = false;
            ChatRoom chatRoomForUpdate = _allCreatedChatRooms.Where(a => a.ChatRoomId == chatRoomId).FirstOrDefault();
            if (chatRoomForUpdate == null) { return chatRoomIsUpdated; }

            Invite targetInviteInfo = chatRoomForUpdate.AllInvitesSentToGuestUsers.Where(a => a.GuestServerUser.ServerUserID == serverUser.ServerUserID).FirstOrDefault();
            if (targetInviteInfo == null) { return chatRoomIsUpdated; }
            targetInviteInfo.InviteStatus = inviteStatus;

            var targetGuestServerUser = chatRoomForUpdate.AllActiveUsersInChatRoom.Where(a => a.ServerUserID == serverUser.ServerUserID).FirstOrDefault();
            switch (inviteStatus)
            {
                case InviteStatus.Accepted:
                    if (targetGuestServerUser == null)
                    {
                        chatRoomForUpdate.AllActiveUsersInChatRoom.Add(serverUser);
                        chatRoomIsUpdated = true;
                    }
                    break;

                case InviteStatus.Rejected:
                    if (targetGuestServerUser != null)
                    {
                        chatRoomForUpdate.AllActiveUsersInChatRoom.Remove(serverUser);
                        chatRoomIsUpdated = true;
                    }
                    break;
            }
            _singleChatRoomUpdateCallback(chatRoomForUpdate);
            _allChatRoomsUpdateCallback(_allCreatedChatRooms);

            return true;
        }

        public bool RemoveUserFromAllActiveUsersInChatRoom(Guid targetChatRoomId, Guid serverUserId)
        {
            bool actionCompleted = false;
            var selectedChatRoom = _allCreatedChatRooms.Where(a => a.ChatRoomId == targetChatRoomId).FirstOrDefault();
            if (selectedChatRoom == null) { return actionCompleted; }
            ServerUser serverUserForDeletion = selectedChatRoom.AllActiveUsersInChatRoom.Where(a => a.ServerUserID == serverUserId).FirstOrDefault();
            if (serverUserForDeletion != null)
            {
                selectedChatRoom.AllActiveUsersInChatRoom.Remove(serverUserForDeletion);
                if (selectedChatRoom.AllActiveUsersInChatRoom.Count <= 0)
                {
                    selectedChatRoom.ChatRoomStatus = ChatRoomStatus.Closed;
                }
                _singleChatRoomUpdateCallback(selectedChatRoom);
                actionCompleted = true;
            }
            _allChatRoomsUpdateCallback(_allCreatedChatRooms);
            return actionCompleted;
        }

        public bool RemoveUserFromAllChatRooms(Guid serverUserId)
        {
            List<ChatRoom> allActiveChatRooms = _allCreatedChatRooms.Where(a => a.ChatRoomStatus == ChatRoomStatus.OpenActive).ToList();
            if (allActiveChatRooms.Count == 0) { return false; }

            foreach (var activeChatRoom in allActiveChatRooms)
            {
                var userForRemoval = activeChatRoom.AllActiveUsersInChatRoom.Where(a => a.ServerUserID == serverUserId).FirstOrDefault();
                if (userForRemoval != null)
                {
                    activeChatRoom.AllActiveUsersInChatRoom.Remove(userForRemoval);
                    if (activeChatRoom.AllActiveUsersInChatRoom.Count <= 0)
                    {
                        activeChatRoom.ChatRoomStatus = ChatRoomStatus.Closed;
                    }

                    _singleChatRoomUpdateCallback(activeChatRoom);
                }
            }
           
            _allChatRoomsUpdateCallback(_allCreatedChatRooms);
            return true;
        }

        public bool RecordMessageInChatRoomConversation(Guid chatRoomId, string message)
        {
            ChatRoom selectedChatRoom = _allCreatedChatRooms.Where(a => a.ChatRoomId == chatRoomId).FirstOrDefault();
            if (selectedChatRoom != null)
            {
                selectedChatRoom.ConversationRecord += CRLF + message;

                _singleChatRoomUpdateCallback(selectedChatRoom);
                _allChatRoomsUpdateCallback(_allCreatedChatRooms);
                return true;
            }

            return false;
        }
    }
}
