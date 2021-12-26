using EveryMessageBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EveryMessageServer.Classes
{
    public class ClientHandler
    {
        private List<TcpClient> ClientList = new List<TcpClient>();
        private Database db;
        public ClientHandler()
        {
            Exception ex = new Exception();
            db = new Database();
            db.GetUser("freekster", "b442fba80e8aa930507dfc15899149bd05172b7791629be87706144b6d119630", ref ex);
        }
        public void HandleClient(TcpClient Client)
        {
            ClientList.Add(Client);
            System.Threading.Thread t = new System.Threading.Thread(HandleConnection);
            t.Start(Client);
        }

        private void HandleConnection(object c)
        {
            TcpClient client = (TcpClient)c;
            NetworkStream stream = client.GetStream();
            System.IO.BinaryReader reader = new System.IO.BinaryReader(stream);
            while (client.Connected)
            {
                if (stream.DataAvailable)
                {

                }
            }
        }
    }
}
