
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Runtime.CompilerServices;

namespace GOF1
{
    internal class Message
    {
        public string FromName { get; set; }
        public string ToName { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        
        // Метод для сериализации в JSON
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        // Статический метод для десериализации JSON в объект Message
        public static Message FromJson(string json)
        {
            return JsonSerializer.Deserialize<Message>(json);
        }

        public Message(string fromName, string toName, string text)
        {
            this.FromName = fromName;
            this.ToName = toName;
            this.Text = text;
            this.Date = DateTime.Now;
        }

        public Message() { }

        public override string ToString()
        {
            return $"Message from {this.FromName} to {this.ToName} ({this.Date}):\n{Text}";
        }

        public string[] DataMessage(string json)
        {
            Message message = Message.FromJson(json);

            // Вывод данных на консоль
            //Console.WriteLine($"From: {message.FromName}");
            //Console.WriteLine($"To: {message.ToName}");
            //Console.WriteLine($"Date: {message.Date}");
            //Console.WriteLine($"Text: {message.Text}");

            string[] DataM = [message.FromName, message.ToName, message.Text];
            return DataM;
        }
    }
}
