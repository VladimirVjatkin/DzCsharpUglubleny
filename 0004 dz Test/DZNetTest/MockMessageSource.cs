using DZNetTest.Abstraction;
using DZNetTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DZNetTest
{ 
    public class MockMessageSource : IMessageSource
    {
        private Queue<MessageUDP> messages = new Queue<MessageUDP>();
  

      public MockMessageSource()
        {
            
            messages.Enqueue(new MessageUDP() { Command = Command.Register, FromName="User001"  });
            messages.Enqueue(new MessageUDP() {Command = Command.Register,FromName="User002" });
            messages.Enqueue(new MessageUDP() { Command = Command.Message, FromName = "User001", ToName = "User002", Text = "PRIVET from User001" });
            messages.Enqueue(new MessageUDP() { Command= Command.Message,FromName="User002",ToName="User001",Text="PRIVET from User002" });
      }
       

        public MessageUDP Receive(ref IPEndPoint iPEndPoint)
        {
           return messages.Dequeue();
        }

        public void Send(MessageUDP messageUDP, IPEndPoint iPEndPoint) 
        {
            messages.Enqueue(messageUDP);
        }

        public void SendResieve(MessageUDP messageUDP)
        {
        
        }
    }
}
