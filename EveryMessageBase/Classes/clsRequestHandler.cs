using EveryMessageBase.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace EveryMessageBase.Classes
{
    public abstract class clsRequestHandler
    {
        public abstract IPackage HandleRequest(byte[] Data);
    }
}
