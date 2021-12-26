using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryMessageBase.Models
{
    public class mPackage
    {
        public Classes.Enums.PackageType PackageType { get; set; }
        public Classes.Enums.MessageType MessageType { get; set; }
        public Classes.Enums.ContentType ContentType { get; set; }
        public long ContentLength { get; set; }
        public byte[] Content { get; set; }
        public Interfaces.IPackage Package { get; set; }
    }
}
