using EveryMessageBase.Interfaces;
using EveryMessageBase.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace EveryMessageServer.Classes
{
    class RequestHandler:EveryMessageBase.Classes.clsRequestHandler
    {
        public override IPackage HandleRequest(byte[] Data)
        {
            Models.Package Package = Deserialize<Models.Package>(Data);
            switch (Package.MessageType)
            {
                case EveryMessageBase.Classes.Enums.MessageType.Login:
                    Package.Package = Deserialize<EveryMessageBase.Packages.LoginPackage.LoginRequest>(Package.Content);
                    break;
            }
        }

        private T Deserialize<T>(byte[] param)
        {
            using (MemoryStream ms = new MemoryStream(param))
            {
                IFormatter br = new BinaryFormatter();
                return (T)br.Deserialize(ms);
            }
        }
    }
}
