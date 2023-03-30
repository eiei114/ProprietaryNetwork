using System;
using System.Threading;

namespace JisakuSerevr
{
    internal class Program
    {
        private static Thread threadConsole;
        
        public static void Main(string[] args)
        {
            threadConsole = new Thread(new ThreadStart(ConsoleThread));
            threadConsole.Start();
            
            NetworkConfig.Initialize();
            NetworkConfig.socket.StartListening(5555,5,1);
            Console.WriteLine("Server started");
        }
        
        private static void ConsoleThread()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    NetworkConfig.socket.StopListening();
                    Environment.Exit(0);
                }
            }
        }
    }
}