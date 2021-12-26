using EveryMessageBase.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace EveryMessageBase.Classes
{
    public class clsPackageHandler
    {
        clsRequestHandler RequestHandler = null;
        clsResponseHandler ResponseHandler = null;
        public clsPackageHandler()
        {
            RequestHandler = new clsRequestHandler();
            ResponseHandler = new clsResponseHandler();
        }

        public Models.mPackage CreatePackage()
        {
            return new Models.mPackage();
        }

        private T Deserialize<T>(byte[] param)
        {
            using (MemoryStream ms = new MemoryStream(param))
            {
                IFormatter br = new BinaryFormatter();
                return (T)br.Deserialize(ms);
            }
        }

        private void SendPackage(NetworkStream stream, IPackage Package)
        {

        }

        private void ReadPackage(byte[] Data)
        {

            Models.mPackage Package = Deserialize<Models.mPackage>(Data);
            Models.mPackage ResponsePackage = null;
            switch (Package.PackageType)
            {
                case Enums.PackageType.Request:
                    RequestHandler.HandleRequest(ref Package);
                    ResponsePackage = ResponseHandler.GenerateResponse(Package);
                    break;
                case Enums.PackageType.Response:

                    break;
                case Enums.PackageType.Status:

                    break;
                case Enums.PackageType.Unknown:

                    break;
            }
        }
        public void HandlePackage(NetworkStream stream)
        {
            List<byte> DataList = new List<byte>();
            byte[] b = new byte[1];
            while (stream.DataAvailable)
            {
                stream.Read(b, 0, 1);
                DataList.Add(b[0]);
            }
            ReadPackage(DataList.ToArray());
        }
    }
}
