using ChatCommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;



namespace CommonLib
{
    public interface IMessageSource 
    {
        void Send(MessageUdp message, string clientId); 
        MessageUdp Receive(ref string? clientId);
        
    }

}
