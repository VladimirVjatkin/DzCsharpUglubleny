
using ChatCommonLib;
using CommonLib;
using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatNetwork
{
    public class UdpMessageSourceServer : IMessageSource
    {
        private readonly RouterSocket _routerSocket = new();

    
        public UdpMessageSourceServer() 
        {
            _routerSocket.Bind($"tcp://*:{12345}");
        }
    

        public MessageUdp Receive(ref string? clientID)
        {
            


            // Получаем само сообщение
            string messageReceived = _routerSocket.ReceiveFrameString();

            return MessageUdp.FromJson(messageReceived) ?? new MessageUdp();
            

          
        }

        public void Send(MessageUdp message, string clientId)
        {
            // Отправляем идентификатор клиента
            _routerSocket.SendMoreFrame(clientId);

            // Отправляем разделитель (обычно пустая строка)
            _routerSocket.SendMoreFrame(""); // Пустой фрейм для разделения метаданных

            // Отправляем само сообщение
            _routerSocket.SendFrame(Encoding.UTF8.GetBytes(message.ToJson()));

            
        }

        
    }
}
