﻿using ChatCommonLib;
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
    public class UdpMessageSourceClient: IMessageSourceClient
    {
        private readonly DealerSocket _dealerSocket;

        public UdpMessageSourceClient(int port , string ipAdress)  
        {
            _dealerSocket = new DealerSocket(); 
            _dealerSocket.Connect($"tcp://{ipAdress}:{port}");
            
        }

        public MessageUdp Receive()
        {
           
              var messageReceived = _dealerSocket.ReceiveFrameString();
                var message = MessageUdp.FromJson(messageReceived) ?? new MessageUdp();

                return message;

        }

     

        public void Send(MessageUdp message)
        {
         _dealerSocket.SendFrame(Encoding.UTF8.GetBytes(message.ToJson()));

        }

    }
}
