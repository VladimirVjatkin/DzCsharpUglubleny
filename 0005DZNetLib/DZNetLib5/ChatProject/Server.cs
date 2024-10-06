using ChatCommonLib;
using ChatProject.Models;
using CommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatProject
{
    public class Server
    {
       private readonly Dictionary<String, string> clients = [];
       private readonly IMessageSource messageSource;

        bool work = true;
        public Server(IMessageSource source)
        {
            messageSource = source;
        }

        void Register(MessageUdp message, string clientId)
        {
            
            clients.Add(message.FromName??"Unknown", clientId);

            using (var ctx = new ChatDbContext())
            {
                if (ctx.Users.FirstOrDefault(x => x.Name == message.FromName) != null) return;
                else
                {
                    ctx.Add(new Users { Name = message.FromName ?? "Unknown" });
                    ctx.SaveChanges();
                }
            }
        }
        void ConfirmMessageReceived(int? id)
        {
           
            using (var ctx = new ChatDbContext()) 
            { 
                var msg = ctx.Messages.FirstOrDefault(x => x.Id == id);
                if (msg != null) 
                {
                    msg.IsReceived = true;
                    ctx.SaveChanges();
                }
            }
        }

        void ReplyMessage(MessageUdp message)
        {
            int? id = null;
            if (clients.TryGetValue(message.ToName ?? "Unknown", out string? clientId))
            {
                using (var ctx = new ChatDbContext())
                {
                    var fromUser = ctx.Users.First(x => x.Name == message.FromName); 
                    var toUser = ctx.Users.First(x => x.Name == message.ToName);
                    var msg = new Messages { FromUserId = fromUser.Id, ToUserId = toUser.Id, IsReceived = false, Text = message.Text };
                    ctx.Messages.Add(msg);
                    ctx.SaveChanges(); 
                    id = msg.Id; 
                }
                var forwardMessage = new MessageUdp() { Id = id, Command = Command.Message, ToName = message.ToName, FromName = message.FromName, Text = message.Text };
                messageSource.Send(forwardMessage, clientId);
                Console.WriteLine($"Message Relied, from = {message.FromName} to = {message.ToName}");
            }
            else { Console.WriteLine("User not found"); }
        }

        void ProcessMessage(MessageUdp message, string fromid)
        {
            
            Console.WriteLine($"Message received from {message.FromName} for {message.ToName} with command {message.Command}:");
            Console.WriteLine(message.Text);
            if (message.Command == Command.Register) 
            {
                Register(message,fromid);
            }
            else if (message.Command == Command.Confirmation) 
            { 
                Console.WriteLine("Confirmation receiver");
                ConfirmMessageReceived(message.Id);
            }
            if (message.Command == Command.Message) 
            { 
                ReplyMessage(message);
            }
        }

        public void Stop() 
        {
        work = false;
        }
      

        public void Work() 
        {
          
            while (work)
            {
                try 
                { 
                    string? clientId = null;
                    var message = messageSource.Receive(ref clientId);
                    if (message == null|| clientId == null) return;
                    else
                    {
                        ProcessMessage(message, clientId);
                    }
                }
                catch (Exception ex)
                { 
                    Console.WriteLine("Error during message processing: " + ex.Message); 
                } 
            } 
        }
    }
}
