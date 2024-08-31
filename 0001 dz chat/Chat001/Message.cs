using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Chat001
{
    internal class Message
    {
        public string FromName { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }


        // Метод для сериализации в JSON
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        // Статический метод для десериализации JSON в объект MyMessage 
        public static Message FromJson(string json)
        {
            return JsonSerializer.Deserialize<Message>(json);
        }

        public Message(string nikname, string text)
        {
            this.FromName = nikname;
            this.Text = text;
            this.Date = DateTime.Now;
        }

        public Message() { }

        public override string ToString()
        {
            return $" We receive message from {this.FromName} ({this.Date}): \n {Text}";
        }
    }

}
