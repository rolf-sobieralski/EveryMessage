using EveryMessageBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace EveryMessageServer.Classes
{
    public class ClientHandler
    {
        private List<TcpClient> ClientList = new List<TcpClient>();
        private Database db;
        private EveryMessageBase.Classes.clsPackageHandler PackageHandler = null;
        public ClientHandler()
        {
            db = new Database();
            PackageHandler = new EveryMessageBase.Classes.clsPackageHandler();
        }
        public void HandleClient(TcpClient Client)
        {
            ClientList.Add(Client);
            System.Threading.Thread t = new System.Threading.Thread(HandleConnection);
            t.Start(Client);
        }

        private T Deserialize<T>(byte[] param)
        {
            using (MemoryStream ms = new MemoryStream(param))
            {
                IFormatter br = new BinaryFormatter();
                return (T)br.Deserialize(ms);
            }
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
                    PackageHandler.HandlePackage(stream);
                }
            }
        }
    }
}
