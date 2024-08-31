using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Sockets;
using System.Net;

namespace Chat001
{
    internal class Chat
    {
        public static void Server(string name)
        {
            UdpClient udpClient;
            IPEndPoint remoteEndPoint;
            udpClient = new UdpClient(12345);
            remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Ser_UDP Client wait messages...");
            while (true)
            {
                byte[] receiveBytes = udpClient.Receive(ref remoteEndPoint);
                string receivedData = Encoding.UTF8.GetString(receiveBytes);
                try
                {
                    var message = Message.FromJson(receivedData);
                    Console.WriteLine($"Ser_Receive message from {message.FromName} ({message.Date}):");
                    Console.WriteLine(message.Text);
                    Console.Write("Type your answer and press Enter: ");
                    string replyMessage = Console.ReadLine();
                    var replyMessageJson = new Message()
                    {
                        Date = DateTime.Now,
                        FromName = name,
                        Text = replyMessage
                    }.ToJson();
                    byte[] replyBytes =
                    Encoding.ASCII.GetBytes(replyMessageJson);
                    udpClient.Send(replyBytes, replyBytes.Length,
                    remoteEndPoint);
                    Console.WriteLine("Response sent.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error during message processing: " +
                    ex.Message);
                }
            }
        }



        public static void Client(string name, string ip)
        {
            UdpClient udpClient;
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);
            udpClient = new UdpClient();
            // remoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);

            while (true)
            {
                try
                {
                    Console.WriteLine("CL_UDP Client wait messages...");
                    Console.Write("CL_Type your answer and press Enter:  ");
                    string message = Console.ReadLine();
                    var messageJson = new Message()
                    {
                        Date = DateTime.Now,
                        FromName = name,
                        Text = message
                    }.ToJson();
                    byte[] replyBytes = Encoding.ASCII.GetBytes(messageJson);
                    udpClient.Send(replyBytes, replyBytes.Length,
                    remoteEndPoint);
                    Console.WriteLine("CL_Response sent.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("CL_Error during message processing: " + ex.Message);
                }
                byte[] receiveBytes = udpClient.Receive(ref remoteEndPoint);
                string receivedData = Encoding.ASCII.GetString(receiveBytes);
                var messageReceived = Message.FromJson(receivedData);
                Console.WriteLine($"CL_Message received from {messageReceived.FromName} ({messageReceived.Date}):");
                Console.WriteLine(messageReceived.Text);

            }
        }





    }
}
