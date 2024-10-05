using DZNetTest.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DZNetTest
{
    public class MessageSource : IMessageSource
    {
        private  readonly UdpClient udpClient;

        public MessageSource(int port) => udpClient = new UdpClient(port);
        public MessageUDP Receive(ref IPEndPoint iPEndPoint)
        {
            
            var recieved = udpClient.Receive(ref iPEndPoint);

            return MessageUDP.FromJson(Encoding.UTF8.GetString(recieved)) ?? new MessageUDP();
        }

        public void Send(MessageUDP messageUdp , IPEndPoint iPEndPoint)
        {
            var json = messageUdp.ToJson();
            udpClient.Send(Encoding.UTF8.GetBytes(json), json.Length, iPEndPoint);
        }
    }
}
