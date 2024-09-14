
using System;
namespace GOF1
{
    internal class Program
    {
        

        static async Task Main(string[] args)
        {
            if (args.Length == 1 && args[0].ToLower() == "start")
            {
                // Запуск сервера через Singleton

                var serverTask = ServerSession.Instance().ServerAsync();
                Console.WriteLine("Press any key to stop the server...");
                Console.ReadKey();

                ServerSession.Instance().StopServer();
                await serverTask;
            }
            else if (args.Length == 3)
            {
                // Запуск клиента с указанием имени, IP и порта
                string name = args[0];
                string ip = args[1];
                int port = int.Parse(args[2]);

                await ClientSession.StartClientAsync(name, ip, port);
            }
            else
            {
                Console.WriteLine("Usage for server: start");
                Console.WriteLine("Usage for client: <name> <server IP> <local port>");
            }
        }
    }
}
















