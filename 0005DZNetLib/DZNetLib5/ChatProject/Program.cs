using ChatNetwork;
using System.Net;


namespace ChatProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            { 
                var s = new Server(new UdpMessageSourceServer());
                s.Work();
            } 
            else if (args.Length == 3) //string _name , string port, string ipAdress
            { 
                var c = new Client(args[0], args[1], args[2]);
                c.Start();
            }
            else 
            {
               
                Console.WriteLine("To start the client, enter the nickname , port and IP of the server as application startup parameters");
            }
        }
    }
}
