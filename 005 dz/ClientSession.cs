
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _005dz
{
    internal class ClientSession
    {
        public static async Task ClientAsync(string name, string ip)
        {
            using (UdpClient udpClient = new UdpClient())
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);

                while (true)
                {
                    Console.Write("Type 'exit' to exit)) \n Type your message and press Enter: ");
                    string message = Console.ReadLine();

                    var messageJson = new Message()
                    {
                        Date = DateTime.Now,
                        FromName = name,
                        Text = message
                    }.ToJson();

                    byte[] sendBytes = Encoding.UTF8.GetBytes(messageJson);
                    await udpClient.SendAsync(sendBytes, sendBytes.Length, remoteEndPoint);

                    // Получаем ответ от сервера асинхронно
                    UdpReceiveResult receiveResult = await udpClient.ReceiveAsync();
                    string receivedData = Encoding.UTF8.GetString(receiveResult.Buffer);
                    Console.WriteLine(receivedData);

                    if (message.ToLower() == "exit")
                    {
                        Console.WriteLine("Session ended.");
                        break;
                    }
                }
            }
        }
    }
}
