using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Chat001
{

    internal class Program
    {
        static void Main(string[] args)
        {

            if (args.Length == 1)
            {
                Chat.Server(args[0]);
            }
            else
            if (args.Length == 2)
            {
                Chat.Client(args[0], args[1]);
            }
            else
            {
                Console.WriteLine("To start the server, enter nickname as an application startup parameter");
                Console.WriteLine("To start the client, enter the nickname and IP of the server as application startup parameters");
            }
        }


    }


}
