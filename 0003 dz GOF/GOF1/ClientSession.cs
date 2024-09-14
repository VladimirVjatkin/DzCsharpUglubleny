
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GOF1
{
    internal class ClientSender
    {
        private readonly UdpClient udpClient;
        private readonly IPEndPoint remoteEndPoint;

        public ClientSender(UdpClient client, IPEndPoint endPoint)
        {
            this.udpClient = client;
            this.remoteEndPoint = endPoint;
        }

        public async Task SendMessagesAsync(string name)
        {
            Console.Write("Rules of messages: \n- Type 'register' for registration in the system\n" +
                                                "- Type 'send NIK(or all) text-message' to friend.\n" +
                                                "- Type 'exit' to exit.\n" +
                                                "- Type your message: \n");

            while (true)
            {
                
                string message = Console.ReadLine();

                var messageJson = new Message(name, "server", message).ToJson();
                byte[] sendBytes = Encoding.UTF8.GetBytes(messageJson);

                await udpClient.SendAsync(sendBytes, sendBytes.Length, remoteEndPoint);

                if (message.ToLower() == "exit")
                {
                    Console.WriteLine("Session ended.");
                    udpClient.Close();
                    return;
                }
            }
        }
    }

    internal class ClientListener
    {
        private readonly UdpClient udpClient;

        public ClientListener(UdpClient client)
        {
            this.udpClient = client;
        }

        public async Task ListenForMessagesAsync()
        {
            while (true)
            {
                UdpReceiveResult receiveResult = await udpClient.ReceiveAsync();
                string receivedData = Encoding.UTF8.GetString(receiveResult.Buffer);
                Console.WriteLine($"Received: {receivedData}");
            }
        }
    }

    internal class ClientSession
    {
        public static async Task StartClientAsync(string name, string ip, int localPort)
        {
            using (UdpClient udpClient = new UdpClient(localPort))
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);

                ClientSender sender = new ClientSender(udpClient, remoteEndPoint);
                ClientListener listener = new ClientListener(udpClient);

                // Запуск двух потоков: один для отправки, другой для получения
                var sendTask = Task.Run(() => sender.SendMessagesAsync(name));
                var listenTask = Task.Run(() => listener.ListenForMessagesAsync());

                await Task.WhenAll(sendTask, listenTask);
            }
        }
    }
}
