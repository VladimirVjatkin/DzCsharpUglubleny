
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _005dz
{
    internal class ServerSession
    {
        private static Dictionary<Task, DateTime> clientTasks = new Dictionary<Task, DateTime>();
        private static object lockObj = new object();
        private static bool isRunning = true;

        public static async Task ServerAsync(string name)
        {
            using (UdpClient udpClient = new UdpClient(12345))
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

                Console.WriteLine("Server is running and waiting for messages...");

                // Запуск мониторинга активных задач
                var monitorTask = MonitorClientTasks();

                try
                {
                    while (isRunning) // Основной цикл сервера
                    {
                        if (udpClient.Available > 0)
                        {
                            UdpReceiveResult receiveResult = await udpClient.ReceiveAsync();
                            string receivedData = Encoding.UTF8.GetString(receiveResult.Buffer);

                            // Обрабатываем клиента в отдельной асинхронной задаче
                            var clientTask = HandleClientAsync(receivedData, receiveResult.RemoteEndPoint, udpClient);
                            lock (lockObj)
                            {
                                clientTasks[clientTask] = DateTime.Now;
                            }
                        }
                        else
                        {
                            await Task.Delay(100); // Небольшая пауза для снижения нагрузки
                        }
                    }
                }
                finally
                {
                    // Закрываем сервер и все клиентские задачи
                    StopServer();
                    await monitorTask;
                }
            }
        }

        public static void StopServer()
        {
            isRunning = false;
        }

        private static async Task HandleClientAsync(string message, IPEndPoint clientEndPoint, UdpClient udpClient)
        {
            // Пример обработки клиентского сообщения
            Console.WriteLine($"Received message: {message}");
            string response = $"Server response to {message}";
            byte[] replyBytes = Encoding.UTF8.GetBytes(response);
            await udpClient.SendAsync(replyBytes, replyBytes.Length, clientEndPoint);

            // Удаляем задачу после завершения
            lock (lockObj)
            {
                clientTasks.Remove(Task.CurrentId.Value);
            }
        }

        private static async Task MonitorClientTasks()
        {
            while (isRunning)
            {
                lock (lockObj)
                {
                    Console.WriteLine($"Active client tasks: {clientTasks.Count}");
                    foreach (var entry in clientTasks)
                    {
                        Console.WriteLine($"Task ID: {entry.Key.Id}, Last Used: {entry.Value}");
                    }
                }
                await Task.Delay(10000); // Пауза перед следующей проверкой
            }
        }
    }
}
