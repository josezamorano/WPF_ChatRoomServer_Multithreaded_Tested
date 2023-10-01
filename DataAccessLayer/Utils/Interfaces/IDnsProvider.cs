using System.Net;

namespace DataAccessLayer.Utils.Interfaces
{
    public interface IDnsProvider
    {
        IPHostEntry GetDnsHostEntry();
    }
}
