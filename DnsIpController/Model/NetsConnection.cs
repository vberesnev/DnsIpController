using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;

namespace DnsIpController.Model
{
    public static class NetsConnection
    {

        private static IPAddress google = new IPAddress(new byte[] { 8, 8, 8, 8});
        private static IPAddress yandex = new IPAddress(new byte[] { 77, 88, 8, 8 });
        private static IPAddress sscyotm = new IPAddress(new byte[] { 219, 154, 102, 1 });
        private static IPAddress omega = new IPAddress(new byte[] { 192, 168, 4, 1 });
        private static string data = "text_connection";
        private static int timeOut = 5000;

        public static bool CheckInternetConnection()
        {
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            return SendPing(google, buffer);
        }

        public static bool CheckOmegaConnection()
        {
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            return SendPing(omega, buffer);
        }

        public static bool CheckSscyotmConnection()
        {
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            return SendPing(sscyotm, buffer);
        }

        private static bool SendPing(IPAddress address, byte[] buffer)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions(3, true);
            PingReply reply = pingSender.Send(address, timeOut);
            return reply.Status == IPStatus.Success;
        }
    }
}
