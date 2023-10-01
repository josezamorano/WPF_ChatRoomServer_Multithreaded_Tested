using ServiceLayer;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;

namespace UnitTestChatRoomServer.ServiceLayerTest
{

    public class ObjectCreatorTest
    {
        IObjectCreator _objectCreator;
        public ObjectCreatorTest()
        {
            _objectCreator = new ObjectCreator();
        }

        [Fact]
        public void CreatePayload_CorrectInput_ReturnsOK()
        {
            //Arrange
            List<ClientInfo> AllClientInfos = new List<ClientInfo>() { new ClientInfo() { Username = "test1", ServerUserID = Guid.NewGuid() } };
            Guid serverUserId = Guid.NewGuid();
            string username = "user_abc";
            //Act
            var actualResult = _objectCreator.CreatePayload(AllClientInfos, ServiceLayer.Enumerations.MessageActionType.CreateUser, serverUserId, username);
            //Assert
            Assert.IsType<Payload>(actualResult);
        }
    }
}
