
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _005dz
{
    internal class ServerSession
    {
        private static bool isRunning = true;

        // Асинхронный метод, который запускает сервер и обрабатывает входящие UDP-сообщения
        public static async Task ServerAsync(string name)
        {
            // Создаем UDP клиент для прослушивания на порту 12345
            using (UdpClient udpClient = new UdpClient(12345))
            {
                // Создаем объект для хранения IP адреса клиента (удаленный конец)
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

                Console.WriteLine("Server is running and waiting for messages...");

                try
                {
                    // Основной цикл работы сервера
                    while (isRunning) // Пока сервер работает
                    {
                        // Проверяем, есть ли входящие данные
                        if (udpClient.Available > 0)
                        {
                            // Асинхронно принимаем данные от клиента
                            UdpReceiveResult receiveResult = await udpClient.ReceiveAsync();
                            // Преобразуем байты в строку
                            string receivedData = Encoding.UTF8.GetString(receiveResult.Buffer);

                            // Обрабатываем сообщение клиента в отдельной асинхронной задаче
                            var clientTask = HandleClientAsync(receivedData, receiveResult.RemoteEndPoint, udpClient);
                        }
                        else
                        {
                            // Если данных нет, делаем паузу, чтобы снизить нагрузку на процессор
                            await Task.Delay(100);
                        }
                    }
                }
                finally
                {
                    udpClient.Close(); // Закрываем UDP клиент
                }
            }
        }

        // Метод для остановки сервера
        public static void StopServer()
        {
            Console.WriteLine("Server ostanovlen");
            isRunning = false;
        }

        // Асинхронный метод для обработки клиентских сообщений
        private static async Task HandleClientAsync(string message, IPEndPoint clientEndPoint, UdpClient udpClient)
        {
            // Выводим на экран сообщение от клиента
            Console.WriteLine($"Received message: {message}");

            // Формируем ответ сервер на сообщение клиента
            string response = $"Server response to {message}";
            byte[] replyBytes = Encoding.UTF8.GetBytes(response);

            // Отправляем ответ клиенту
            await udpClient.SendAsync(replyBytes, replyBytes.Length, clientEndPoint);
        }
    }
}
