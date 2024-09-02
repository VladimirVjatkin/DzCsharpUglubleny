using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Chat002x
{
    internal class ServerSession
    {
        // Словарь для хранения потоков клиентов и времени их последнего использования
        private static Dictionary<Thread, DateTime> clientThreads = new Dictionary<Thread, DateTime>();
        private static object lockObj = new object(); // Объект для синхронизации доступа к словарю

        public static void Server(string name)
        {
            UdpClient udpClient = new UdpClient(12345);
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

            Console.WriteLine("Server is running and waiting for messages...");

            // Запускаем отдельный поток для периодического вывода информации о клиентах
            Thread monitorThread = new Thread(MonitorClientThreads);
            monitorThread.Start();

            try
            {
                while (true) // Основной цикл сервера
                {
                    if (udpClient.Available > 0) // Проверяем, есть ли данные для чтения
                    {
                        byte[] receiveBytes = udpClient.Receive(ref remoteEndPoint);
                        string receivedData = Encoding.ASCII.GetString(receiveBytes);

                        // Обрабатываем сообщение в отдельном потоке
                        Thread clientThread = new Thread(() => HandleClient(receivedData, remoteEndPoint, udpClient));
                        lock (lockObj)
                        {
                            clientThreads[clientThread] = DateTime.Now; // Добавляем поток клиента в словарь
                        }
                        clientThread.Start();
                    }
                    else
                    {
                        Thread.Sleep(100); // Даем потоку небольшую паузу, чтобы снизить нагрузку на процессор
                    }
                }
            }
            catch (ThreadAbortException)
            {
                Console.WriteLine("Server is stopping...");

                // Закрываем все клиентские потоки перед завершением работы
                CloseAllClientThreads();

                // Завершаем поток мониторинга
                monitorThread.Abort();
            }
            finally
            {
                udpClient.Close(); // Закрываем UDP-клиент при завершении работы сервера
                Console.WriteLine("Server has stopped.");
            }
        }

        private static void HandleClient(string messageData, IPEndPoint clientEndPoint, UdpClient udpClient)
        {
            try
            {
                var message = Message.FromJson(messageData);

                // Приветствуем клиента
                string welcomeMessage = $"Hello, {message.FromName}";
                byte[] replyBytes = Encoding.ASCII.GetBytes(welcomeMessage);
                udpClient.Send(replyBytes, replyBytes.Length, clientEndPoint);

                // Обновляем время последнего использования потока
                lock (lockObj)
                {
                    clientThreads[Thread.CurrentThread] = DateTime.Now;
                }

                if (message.Text.ToLower() == "exit")
                {
                    // Если клиент отправил "exit", попрощаемся
                    string goodbyeMessage = $"Goodbye, {message.FromName}";
                    replyBytes = Encoding.ASCII.GetBytes(goodbyeMessage);
                    udpClient.Send(replyBytes, replyBytes.Length, clientEndPoint);

                    // Удаляем поток из списка работающих потоков
                    lock (lockObj)
                    {
                        clientThreads.Remove(Thread.CurrentThread);
                    }

                    // Завершаем поток клиента
                    Thread.CurrentThread.Abort();
                }
            }
            catch (ThreadAbortException)
            {
                // Корректно завершить поток клиента
                lock (lockObj)
                {
                    clientThreads.Remove(Thread.CurrentThread);
                }
            }
        }

        private static void MonitorClientThreads()
        {
            while (true)
            {
                lock (lockObj)
                {
                    Console.WriteLine($"Active client threads: {clientThreads.Count}");
                    foreach (var entry in clientThreads)
                    {
                        Console.WriteLine($"Thread ID: {entry.Key.ManagedThreadId}, Last Used: {entry.Value}");
                    }
                }
                Thread.Sleep(9000); // Пауза 5 секунд перед следующей проверкой
            }
        }

        private static void CloseAllClientThreads()
        {
            lock (lockObj)
            {
                foreach (var clientThread in clientThreads.Keys)
                {
                    try
                    {
                        if (clientThread.IsAlive)
                        {
                            clientThread.Abort(); // Завершаем каждый клиентский поток
                        }
                    }
                    catch (ThreadAbortException)
                    {
                        // Поглощаем исключение, так как мы ожидаем завершения потоков
                    }
                }
                clientThreads.Clear(); // Очищаем словарь после завершения всех потоков
            }
        }
    }
}

