
// Подключение необходимых пространств имен для работы с сетевыми и системными функциями
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Xml.Linq;
using System.Reflection.Metadata;

namespace GOF1
{
    // Класс ServerSession отвечает за работу сервера и обработку клиентских сообщений
    internal class ServerSession
    {
        // Флаг для отслеживания состояния работы сервера (запущен/остановлен)
        private static bool isRunning = true;

        // Словарь для хранения зарегистрированных клиентов (ключ - имя клиента, значение - IP-адрес клиента)
        private static Dictionary<string, IPEndPoint> clients = new Dictionary<string, IPEndPoint>();

        // Асинхронный метод, который запускает сервер и обрабатывает входящие UDP-сообщения
        public static async Task ServerAsync()
        {
            // Создание UDP клиента, который будет прослушивать сообщения на порту 12345
            using (UdpClient udpClient = new UdpClient(12345))
            {
                // Создание объекта для хранения IP адреса удаленного клиента
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

                Console.WriteLine("Server is running and waiting for messages...");

                try
                {
                    // Основной цикл работы сервера
                    while (isRunning)
                    {
                        // Проверка наличия данных в буфере UDP клиента
                        if (udpClient.Available > 0)
                        {
                            // Асинхронное получение данных от клиента
                            UdpReceiveResult receiveResult = await udpClient.ReceiveAsync();
                            string receivedData = Encoding.UTF8.GetString(receiveResult.Buffer); // Преобразование данных в строку

                            // Обработка полученного сообщения
                            await HandleClientAsync(receivedData, receiveResult.RemoteEndPoint, udpClient);
                        }
                        else
                        {
                            // Если данных нет, пауза для снижения нагрузки на процессор
                            await Task.Delay(100);
                        }
                    }
                }
                finally
                {
                    udpClient.Close(); // Закрытие UDP клиента при остановке сервера
                }
            }
        }

        // Метод для остановки сервера
        public static void StopServer()
        {
            Console.WriteLine("Server stopped"); // Вывод сообщения о завершении работы сервера
            isRunning = false; // Установка флага для остановки основного цикла
        }


        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

        // Асинхронный метод для обработки сообщений от клиентов
        private static async Task HandleClientAsync(string message, IPEndPoint clientEndPoint, UdpClient udpClient)
        {
            Console.WriteLine($"Received message: {message}"); // Вывод полученного сообщения
            Message mess = Message.FromJson(message);

            string? fullMessage = mess.Text;
                        
            // Разделение строки на максимум три части
            string[] messageParts = mess.Text.Split(' ', 3);

            // Проверяем, есть ли хотя бы одно слово (команда)
            string? command = messageParts.Length > 0 ? messageParts[0] : null;

            // Проверяем, есть ли второе слово (кому)
            string? toName = messageParts.Length > 1 ? messageParts[1] : null;

            // Проверяем, есть ли третья часть (текст)
            string? text = messageParts.Length > 2 ? messageParts[2] : null;


            // Если команда "register" - регистрация клиента
            if (command.ToLower() == "register") 
            {
                string? clientName = mess.FromName; // Имя клиента

                // Если клиента еще нет в словаре, добавляем его
                if (!clients.ContainsKey(clientName))
                {
                    clients.Add(clientName, clientEndPoint);
                    Console.WriteLine($"Client {clientName} registered with endpoint {clientEndPoint}");
                    await SendMessageAsync($"\n Client {clientName} registered with endpoint{clientEndPoint}", clientEndPoint, udpClient);
                }
            }
            // Если команда "send" - отправка сообщения
            else if (command.ToLower() == "send")
            {
                /* // Запрос у клиента что то ввести  
                string requestRecipient = "Please write POLUCHATEL:";
                byte[] requestRecipientBytes = Encoding.UTF8.GetBytes(requestRecipient);
                await udpClient.SendAsync(requestRecipientBytes, requestRecipientBytes.Length, clientEndPoint);

                // Получение ответа от клиента с именем получателя
                UdpReceiveResult receiveResult = await udpClient.ReceiveAsync();
                string? codeMess01 = Encoding.UTF8.GetString(receiveResult.Buffer);
                Message mess01 = Message.FromJson(codeMess01);
                string? toName = mess01.Text;
                 */
                

                // Если указано "all", сообщение отправляется всем клиентам
                if (toName != null && toName.ToLower() == "all")
                {   
                    string? sendername = mess.FromName.ToLower();

                    foreach (var clientEntry in clients)
                    {
                        string clientName = clientEntry.Key.ToLower(); // Имя клиента
                        var clientEndPoint1 = clientEntry.Value;        // IP-адрес клиента

                        // Исключаем отправителя из списка
                        if (clientName != sendername)
                        {
                            await SendMessageAsync($"Message from {mess.FromName} for ALL users - {text}", clientEndPoint1, udpClient);
                        }
                    }
                }
                // Если указан конкретный клиент, отправляем сообщение только ему
                else if (toName != null && clients.ContainsKey(toName))
                {
                    await SendMessageAsync($"Message from {mess.FromName} - {text}", clients[toName], udpClient);
                }
                else
                {
                    Console.WriteLine($"Client {toName} not found."); // Сообщение о том, что клиент не найден
                    await SendMessageAsync($"\n Client {toName} not found", clientEndPoint, udpClient);

                }
            }
            // Если команда "exit" - удаление клиента
            else if (command.ToLower() == "exit")
            {
                string clientName = mess.FromName; // Имя клиента

                // Если клиент зарегистрирован, удаляем его из словаря
                if (clients.ContainsKey(clientName))
                {
                    clients.Remove(clientName);
                    Console.WriteLine($"Client {clientName} has exited and been removed.");
                }
            }
        }

        // Асинхронный метод для отправки сообщения клиенту
        private static async Task SendMessageAsync(string message, IPEndPoint clientEndPoint, UdpClient udpClient)
        {
            // Формирование сообщения для отправки
            string response = $"Server to {clientEndPoint}: {message}";
            byte[] replyBytes = Encoding.UTF8.GetBytes(response); // Преобразование сообщения в байты
            await udpClient.SendAsync(replyBytes, replyBytes.Length, clientEndPoint); // Отправка сообщения клиенту
        }
    }
}
