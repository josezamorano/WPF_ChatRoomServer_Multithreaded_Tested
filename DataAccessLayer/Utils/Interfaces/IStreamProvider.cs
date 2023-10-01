using System.IO;
using System.Net.Sockets;

namespace DataAccessLayer.Utils.Interfaces
{
    public interface IStreamProvider
    {
        StreamReader CreateStreamReader(NetworkStream networkStream);

        StreamWriter CreateStreamWriter(NetworkStream networkStream);
    }
}
