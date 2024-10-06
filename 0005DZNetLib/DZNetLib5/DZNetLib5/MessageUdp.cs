﻿using System.Text.Json;

namespace ChatCommonLib
{

    public enum Command
    {
        Register,
        Message,
        Confirmation,
        SendListOfUnreadMessages
    }
    public class MessageUdp
    {

        public Command Command { get; set; }
        public int? Id { get; set; }
        public string? FromName { get; set; }
        public string? ToName { get; set; }
        public string? Text { get; set; }
        //To Json serialization method
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        //From Json deserialization method
        public static MessageUdp? FromJson(string json)
        {
            return JsonSerializer.Deserialize<MessageUdp>(json);
        }
        public override string ToString()
        {
            return $" FromName: {FromName}, ToName: {ToName}, Text: {Text}";
        }
    }
}
