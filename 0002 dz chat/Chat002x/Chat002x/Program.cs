using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Chat002x
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                // Создаем и запускаем сервер в отдельном потоке
                Thread serverThread = new Thread(() => ServerSession.Server(args[0]));
                serverThread.Start();

                // Ожидаем нажатия клавиши для завершения работы сервера
                Console.WriteLine("Press any key to stop the server...");
                Console.ReadKey();

                // Завершаем поток сервера с использованием Thread.Abort
                serverThread.Abort(); // Завершаем поток сервера
                serverThread.Join();  // Ждем завершения работы потока сервера
            }
            else if (args.Length == 2)
            {
                // Запуск клиента в основном потоке
                ClientSession.Client(args[0], args[1]);
            }
            else
            {
                Console.WriteLine("To start the server, enter nickname as an application startup parameter");
                Console.WriteLine("To start the client, enter the nickname and IP of the server as application startup parameters");
            }
        }
    }
}
