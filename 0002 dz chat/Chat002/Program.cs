using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                ServerSession.Server(args[0]);
            }
            else
            if (args.Length == 2)
            {
                for (int i = 0; i < 5; i++)
                {
                    new Thread(() => {
                        ClientSession.Client(args[0] + i.ToString(), args[1]);
                    }).Start();
                    Thread.Sleep(10000); 
                }
            }
            else
            {
                Console.WriteLine("To start the server, enter nickname as an application startup parameter");
                Console.WriteLine("To start the client, enter the nickname and IP of the server as application startup parameters");
            }
        }
    }



}


