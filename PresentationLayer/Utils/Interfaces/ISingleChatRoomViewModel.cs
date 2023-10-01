using System.Windows.Input;

namespace PresentationLayer.Utils.Interfaces
{
    public interface ISingleChatRoomViewModel
    {
        public string GridSingleChatRoomVisibility { get; set; }

        public ICommand ButtonSingleChatRoomGoBackCommand { get; set; }
    }
}
