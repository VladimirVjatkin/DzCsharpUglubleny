using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace Chat002
{
    static class ServerSession
    {
        public static void Server(string name)
        {
            UdpClient udpClient;
            udpClient = new UdpClient(12345);
            Console.WriteLine("Server UDP wait messages...");
            while (true)
            {
                IPEndPoint remoteEndPoint;
                remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] receiveBytes = udpClient.Receive(ref remoteEndPoint);
                string receivedData = Encoding.UTF8.GetString(receiveBytes);
                new Thread(() =>
                {
                    try
                    {
                        var message = Message.FromJson(receivedData);
                        Console.WriteLine($"Recieve message from {message.FromName} ({message.Date}):");
                        Console.WriteLine(message.Text);
                        string replyMessage = "Message received";
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
                        Console.WriteLine("Answer sent.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error during message processing: " + ex.Message);
                    }
                }).Start();
            }
        }
    }
}
