﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace DZNetTest
{

    public enum Command
    {
        Register,
        Message,
        Confirmation
    }
    public class MessageUDP
    {
        public Command Command { get; set; }
        public int? Id { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string Text { get; set; }


        public override string ToString()
        {
            return $"{DateTime.Now} \n Recieved message from {Text}, \n from {FromName}";
        }

        // Метод для сериализации в JSON
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        // Статический метод для десериализации JSON в объект MyMessage
        public static MessageUDP FromJson(string json)
        {
            return JsonSerializer.Deserialize<MessageUDP>(json);
        }
    }

}
