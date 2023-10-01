﻿using ServiceLayer.Enumerations;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    public class ObjectCreator : IObjectCreator
    {
        public Payload CreatePayload(List<ClientInfo> allConnectedClients, MessageActionType messageActionType, Guid? userId, string username)
        {
            List<ServerUser> allActiveServerUsers = CreateServerUsersFromAllConnectedClients(allConnectedClients);
            Payload createdPayload = new Payload()
            {
                MessageActionType = messageActionType,
                UserId = userId,
                ClientUsername = username,
                ActiveServerUsers = allActiveServerUsers,
            };

            return createdPayload;
        }

        public Payload CreatePayload(List<ClientInfo> allConnectedClients, MessageActionType messageActionType, ServerUser activeServerUser, ServerUser serverUser)
        {
            ServerUser serverUserDisconnected = (messageActionType == MessageActionType.ServerUserIsDisconnected) ? serverUser : null;
            ServerUser serverUserRemovedFromChatRoom = (messageActionType == MessageActionType.ServerUserRemovedFromChatRoom) ? serverUser : null;
            List<ServerUser> allActiveServerUsers = CreateServerUsersFromAllConnectedClients(allConnectedClients);
            Payload createdPayload = new Payload()
            {
                MessageActionType = messageActionType,
                UserId = activeServerUser.ServerUserID,
                ClientUsername = activeServerUser.Username,
                ActiveServerUsers = allActiveServerUsers,
                ServerUserDisconnected = serverUserDisconnected,
                ServerUserRemovedFromChatRoom = serverUserRemovedFromChatRoom
            };

            return createdPayload;
        }


        public Payload CreatePayload(List<ClientInfo> allConnectedClients, MessageActionType messageActionType, ServerUser serverUser, ChatRoom chatRoom)
        {
            List<ServerUser> allActiveServerUsers = CreateServerUsersFromAllConnectedClients(allConnectedClients);
            Payload createdPayload = new Payload()
            {
                MessageActionType = messageActionType,
                UserId = serverUser.ServerUserID,
                ClientUsername = serverUser.Username,
                ActiveServerUsers = allActiveServerUsers,
                ChatRoomCreated = chatRoom
            };

            return createdPayload;
        }

        public Payload CreatePayload(List<ClientInfo> allConnectedClients, MessageActionType messageActionType, ServerUser targetServerUser, Invite invite)
        {
            List<ServerUser> allActiveServerUsers = CreateServerUsersFromAllConnectedClients(allConnectedClients);
            Payload createdPayload = new Payload()
            {
                MessageActionType = messageActionType,
                UserId = targetServerUser.ServerUserID,
                ClientUsername = targetServerUser.Username,
                ActiveServerUsers = allActiveServerUsers,
                InviteToGuestUser = invite
            };

            return createdPayload;
        }

        public Payload CreatePayload(List<ClientInfo> allConnectedClients, MessageActionType messageActionType, ServerUser targetServerUser, ChatRoom chatRoom, string messageToChatRoom)
        {
            List<ServerUser> allActiveServerUsers = CreateServerUsersFromAllConnectedClients(allConnectedClients);
            Payload createdPayload = new Payload()
            {
                MessageActionType = messageActionType,
                UserId = targetServerUser.ServerUserID,
                ClientUsername = targetServerUser.Username,
                ActiveServerUsers = allActiveServerUsers,
                ChatRoomCreated = chatRoom,
                MessageToChatRoom = messageToChatRoom
            };

            return createdPayload;
        }

        public Payload CreatePayload(List<ClientInfo> allConnectedClients, MessageActionType messageActionType, ServerUser targetServerUser, ChatRoom chatRoom, Invite invite)
        {
            List<ServerUser> allActiveServerUsers = CreateServerUsersFromAllConnectedClients(allConnectedClients);
            Payload createdPayload = new Payload()
            {
                MessageActionType = messageActionType,
                UserId = targetServerUser.ServerUserID,
                ClientUsername = targetServerUser.Username,
                ActiveServerUsers = allActiveServerUsers,
                ChatRoomCreated = chatRoom,
                InviteToGuestUser = invite
            };

            return createdPayload;
        }


        public Payload CreatePayload(List<ClientInfo> allConnectedClients, MessageActionType messageActionType, ServerUser targetServerUser, ChatRoom chatRoom, ServerUser serverUser)
        {
            ServerUser serverUserDisconnected = (messageActionType == MessageActionType.ServerUserIsDisconnected) ? serverUser : null;
            ServerUser serverUserRemovedFromChatRoom = (messageActionType == MessageActionType.ServerUserRemovedFromChatRoom) ? serverUser : null;

            List<ServerUser> allActiveServerUsers = CreateServerUsersFromAllConnectedClients(allConnectedClients);
            Payload createdPayload = new Payload()
            {
                MessageActionType = messageActionType,
                UserId = targetServerUser.ServerUserID,
                ClientUsername = targetServerUser.Username,
                ActiveServerUsers = allActiveServerUsers,
                ChatRoomCreated = chatRoom,
                ServerUserDisconnected = serverUserDisconnected,
                ServerUserRemovedFromChatRoom = serverUserRemovedFromChatRoom
            };

            return createdPayload;
        }


        public ChatRoom CreateChatRoom(string chatRoomName, ServerUser serverUserCreator, List<ServerUser> allActiveUsersInChatRoom, List<Invite> allInvitesSentToGuestUsers)
        {
            Guid newId = Guid.NewGuid();
            string chatRoomIdentifier = chatRoomName + "_" + newId;
            ChatRoom chatRoomCreated = new ChatRoom()
            {
                ChatRoomName = chatRoomName,
                ChatRoomId = newId,
                ChatRoomIdentifierNameId = chatRoomIdentifier,
                ChatRoomStatus = ChatRoomStatus.OpenActive,
                Creator = serverUserCreator,
                ConversationRecord = string.Empty,
                AllActiveUsersInChatRoom = allActiveUsersInChatRoom,
                AllInvitesSentToGuestUsers = allInvitesSentToGuestUsers
            };
            //Add InviteID and sent to all guest Server Users
            foreach (Invite inviteToGuest in chatRoomCreated.AllInvitesSentToGuestUsers)
            {
                inviteToGuest.InviteId = Guid.NewGuid();
                inviteToGuest.InviteStatus = InviteStatus.SentAndPendingResponse;
                inviteToGuest.ChatRoomId = newId;
            }

            return chatRoomCreated;
        }

        #region Private Methods
        private List<ServerUser> CreateServerUsersFromAllConnectedClients(List<ClientInfo> allConnectedClients)
        {
            var serverUsers = allConnectedClients.Select(a => new { a?.Username, a?.ServerUserID });
            List<ServerUser> allActiveServerUsers = new List<ServerUser>();
            foreach (var user in serverUsers)
            {
                ServerUser serverUser = new ServerUser()
                {
                    Username = user.Username,
                    ServerUserID = user.ServerUserID,
                };
                allActiveServerUsers.Add(serverUser);
            }

            return allActiveServerUsers;
        }

        #endregion Private Methods
    }
}
