using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EveryMessageServer.Classes
{
    public class ServerInstance
    {
        private TcpListener Server;
        IPAddress ServerIP;
        int Port;
        bool Running = false;
        private ClientHandler clientHandler;
        private Database db;
        public ServerInstance(IPAddress address = null, int port = 34150)
        {
            Port = port;
            if (address == null)
            {
                ServerIP = GetLocalIPAddress();
            }
            else
            {
                ServerIP = address;
            }

            Server = new TcpListener(ServerIP, Port);
            clientHandler = new ClientHandler();
            System.Threading.Thread t = new System.Threading.Thread(ServerStart);
            t.Start();
            WriteConsoleWelcome();
        }

        private void ServerStart()
        {
            Running = true;
            Server.Start();
            while (Running)
            {
                if (Server.Pending())
                {
                    clientHandler.HandleClient(Server.AcceptTcpClient());
                }
            }

        }

        public void Stop()
        {
            Running = false;
        }
        private string GenerateLine(string Content, char? Border, int length)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Border);
            int FirstHalf = 0;
            int SecondHalf = 0;
            if(Border != null)
            {
                length = length - 1;
            }
            if (Content.Length >= length)
            {
                Content = Content.Substring(1, length - 1);
                sb.Append(Content);

            }
            else
            {
                int Spaces = length - Content.Length;
                if(Spaces % 2 == 0)
                {
                    FirstHalf = Spaces / 2;
                    SecondHalf = FirstHalf;
                }
                else
                {
                    FirstHalf = (Spaces - 1) / 2;
                    SecondHalf = FirstHalf+1;
                    
                }
            }
            for(int i = 0; i < FirstHalf; i++)
            {
                sb.Append(" ");
            }
            sb.Append(Content);
            for(int i = 0; i< SecondHalf; i++)
            {
                sb.Append(" ");
            }
            sb.Append(Border);
            return sb.ToString();
        }
        private void WriteConsoleWelcome()
        {
            StringBuilder sb = new StringBuilder();
            string Text = "EveryMessage Server";
            int RowLength = 48;
            for(int i = 0; i <= RowLength; i++)
            {
                sb.Append("#");
            }
            Console.WriteLine(sb.ToString());
            Console.WriteLine(GenerateLine(Text, '#', RowLength));
            Console.WriteLine(GenerateLine("", '#', RowLength));
            Console.WriteLine(GenerateLine("Server IP: " + ServerIP.ToString(), '#', RowLength));
            Console.WriteLine(GenerateLine("Port: " + Port.ToString(), '#', RowLength));
            Console.WriteLine(GenerateLine("", '#', RowLength));
            Console.WriteLine(sb.ToString());
        }
        public IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

    }
}
