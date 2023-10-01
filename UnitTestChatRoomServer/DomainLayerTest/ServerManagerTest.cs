﻿using DataAccessLayer.IONetwork;
using DataAccessLayer.Utils.Interfaces;
using DomainLayer;
using DomainLayer.Utils.Interfaces;
using ServiceLayer;
using ServiceLayer.Interfaces;
using UnitTestChatRoomServer.MockClasses;

namespace UnitTestChatRoomServer.DomainLayerTest
{

    public class ServerManagerTest
    {
        IClientAction _clientAction;
        IMessageDispatcher _messageDispatcher;
        ISerializationProvider _serializationProvider;
        ITransmitter _transmitter;
        IObjectCreator _objectCreator;
        IDnsProvider _dnsProvider;

        IServerManager _serverManager;


        public ServerManagerTest()
        {
            _objectCreator = new ObjectCreator();

            _serializationProvider = new SerializationProvider();
            _transmitter = new Mock_Transmitter();
            _messageDispatcher = new MessageDispatcher(_objectCreator, _serializationProvider, _transmitter);
            _clientAction = new Mock_ClientAction();
            _dnsProvider = new Mock_DnsProvider();
            _serverManager = new ServerManager(_clientAction, _messageDispatcher, _dnsProvider);
        }

        [Fact]
        public void GetLocalIP_CorrectInput_ReturnsOK()
        {
            //Arrange
            string expectedIP = "82.170.8.0";
            //Act
            var actualResult = _serverManager.GetLocalIP();
            //Assert
            Assert.Equal(expectedIP, actualResult);
        }
    }
}
