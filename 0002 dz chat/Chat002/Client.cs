using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Sockets;
using System.Net;


namespace Chat002
{
    static class ClientSession
    {
        public static void Client(string name, string ip)
        {
            UdpClient udpClient;
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);
            udpClient = new UdpClient();
            remoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);

            //while (true)
            //{
                try
                {
                    Console.Write("CLient - Type your message and press Enter:  ");
                    string message = Console.ReadLine();
                    //string message = "Privet!";
                    var messageJson = new Message()
                    {
                        Date = DateTime.Now,
                        FromName = name,
                        Text = message
                    }.ToJson();
                    byte[] replyBytes = Encoding.UTF8.GetBytes(messageJson);
                    udpClient.Send(replyBytes, replyBytes.Length, remoteEndPoint);
                    Console.WriteLine("Message sent.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error during message processing:" + ex.Message);
                }
                byte[] receiveBytes = udpClient.Receive(ref remoteEndPoint);
                string receivedData = Encoding.UTF8.GetString(receiveBytes);
                var messageReceived = Message.FromJson(receivedData);
                Console.WriteLine($"Message recieved from {messageReceived.FromName} ({messageReceived.Date}):");
                Console.WriteLine(messageReceived.Text);
            //}
        }
    }
}
