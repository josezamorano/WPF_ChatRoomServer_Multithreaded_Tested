using DataAccessLayer.Utils.Interfaces;
using System.Net;

namespace DataAccessLayer.IONetwork
{
    public class DnsProvider : IDnsProvider
    {

        public IPHostEntry GetDnsHostEntry()
        {
            var result = Dns.GetHostEntry(Dns.GetHostName());
            return result;
        }
    }
}
