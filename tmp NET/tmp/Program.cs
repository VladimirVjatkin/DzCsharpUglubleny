
using System;
using System.Threading.Tasks;

namespace _005dz
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 1)
            {
                // Асинхронный запуск сервера с использованием Task вместо Thread
                var serverTask = ServerSession.ServerAsync(args[0]);

                // Ожидаем нажатия клавиши для завершения работы сервера
                Console.WriteLine("Press any key to stop the server...");
                Console.ReadKey();

                // Асинхронная отмена сервера (без использования Thread.Abort)
                ServerSession.StopServer();

                // Ожидаем завершения работы сервера
                await serverTask;
            }
            else if (args.Length == 2)
            {
                // Асинхронный запуск клиента
                await ClientSession.ClientAsync(args[0], args[1]);
            }
            else
            {
                Console.WriteLine("To start the server, enter nickname as an application startup parameter");
                Console.WriteLine("To start the client, enter the nickname and IP of the server as application startup parameters");
            }
        }
    }
}
