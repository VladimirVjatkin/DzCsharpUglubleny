﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace DZNetTest
{
   
    
        public enum Command
        {
            Register,
            Message,
            Confirmation,
            SendListOfUnreadMessages
        }
        public class MessageUDP 
        {
     
            public Command Command { get; set; }
            public int? Id { get; set; }
            public string FromName { get; set; }
            public string ToName { get; set; }
            public string Text { get; set; } 
            //To Json serialization method
            public string ToJson() 
            {
            return JsonSerializer.Serialize(this);
            }

            //From Json deserialization method
            public static MessageUDP? FromJson(string json)
            {
            return JsonSerializer.Deserialize<MessageUDP>(json);
            }
        public override string ToString()
        {
            return $" FromName: {FromName}, ToName: {ToName}, Text: {Text}";
        }



    }
    
}
