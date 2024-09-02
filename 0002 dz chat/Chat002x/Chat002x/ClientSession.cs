using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Chat002x
{
    internal class ClientSession
    {
        public static void Client(string name, string ip)
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);

            while (true)
            {
                Console.Write("Type your message and press Enter: ");
                string message = Console.ReadLine();

                var messageJson = new Message()
                {
                    Date = DateTime.Now,
                    FromName = name,
                    Text = message
                }.ToJson();

                byte[] sendBytes = Encoding.UTF8.GetBytes(messageJson);
                udpClient.Send(sendBytes, sendBytes.Length, remoteEndPoint);

                // Получаем ответ от сервера
                byte[] receiveBytes = udpClient.Receive(ref remoteEndPoint);
                string receivedData = Encoding.UTF8.GetString(receiveBytes);
                Console.WriteLine(receivedData);

                if (message.ToLower() == "exit")
                {
                    Console.WriteLine("Session ended.");
                    break;
                }
            }

            udpClient.Close();
        }
    }
}