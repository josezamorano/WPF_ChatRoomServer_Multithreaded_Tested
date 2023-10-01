using ServiceLayer.Models;

namespace PresentationLayer.Utils.Interfaces
{
    public interface IAllChatRoomsViewModel
    {
        public string GridAllChatRoomsVisibility { get; set; }
        public ChatRoom SelectedItemChatRoom { get; set; }
    }
}
