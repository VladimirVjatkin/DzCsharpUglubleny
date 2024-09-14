
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GOFpatterny4s
{
    // Класс ServerSession отвечает за работу сервера и обработку клиентских сообщений
    internal class ServerSession
    {
        private static ServerSession instance;
        private ServerSession() { }
        public static ServerSession Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServerSession();
                }
                return instance;
            }
        }
    {
        // Поле для хранения единственного экземпляра класса
        private static ServerSession instance;

        // Флаг для отслеживания состояния работы сервера (запущен/остановлен)
        private static bool isRunning = true;

        // Словарь для хранения зарегистрированных клиентов (ключ - имя клиента, значение - IP-адрес клиента)
        private Dictionary<string, IPEndPoint> clients = new Dictionary<string, IPEndPoint>();

        // Закрытый конструктор для предотвращения создания других экземпляров
        private ServerSession() { }

        // Метод для получения единственного экземпляра класса
        public static ServerSession Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServerSession();
                }
                return instance;
            }
        }

        // Асинхронный метод, который запускает сервер и обрабатывает входящие UDP-сообщения
        public async Task ServerAsync()
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

                            Console.WriteLine($"Received message: {receivedData}");

                            // Логика обработки сообщения и добавление клиента
                            // Пример: clients["name"] = remoteEndPoint;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        // Метод для остановки сервера
        public static void StopServer()
        {
            isRunning = false;
            Console.WriteLine("Server has stopped.");
        }
    }
}
