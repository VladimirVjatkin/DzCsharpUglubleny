using ChatCommonLib;
using ChatNetwork;
using CommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ChatProject
{
    public class Client
    {
        private readonly string _name;

        private readonly IMessageSourceClient client;

        public Client(string name , string port, string ipAdress)
        {
            this._name = name;
            if (int.TryParse(port, out int x))
            {
                client = new UdpMessageSourceClient(x, ipAdress);
            }
            else
            {
                throw new Exception("Incorrect port");
            }
            
           
        }

        void ClientListener() 
        {

            while (true) 
            {
                try 
                {
                var messageReceived = client.Receive();
                    Console.WriteLine("Message recieved from" + messageReceived.FromName + " : " + messageReceived.Text);
                    Confirm(messageReceived);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        void Confirm(MessageUdp message) 
        {
            var messageConfirm= new MessageUdp
            {
                FromName = _name,
                Text = null,
                ToName = null,
                Id = message.Id,
                Command = Command.Confirmation
            };
            client.Send(messageConfirm);
        }

        void Register() 
        {
            var message = new MessageUdp {FromName=_name,Text=null,ToName=null,Command=Command.Register}; 

            client.Send(message);
        }

        void ClientSender() 
        {
            Register();

            while (true) 
            {
                try 
                {
                    Console.WriteLine("Enter receiver name and the text and press Enter ");
                    var messages = Console.ReadLine()?.Split(' ');

                    var message = new MessageUdp() {Command=Command.Message,FromName=_name,ToName=messages?[0],Text=messages?[1]};

                    client.Send(message);
                    Console.WriteLine("Message sent");

                } catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

            }
        }

        public void Start() 
        {
            new Thread(() => ClientListener()).Start();
            ClientSender();
        }
    }
}
