using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DZNetTest.Abstraction
{
    public interface IMessageSource
    {
        void Send(MessageUDP messageUdp , IPEndPoint iPEndPoint);

         MessageUDP Receive(ref IPEndPoint iPEndPoint);
    }
}
