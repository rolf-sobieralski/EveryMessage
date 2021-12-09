using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryMessage.Models
{
    public class mPackage
    {
        int PackageType { get; set; }
        int MessageType { get; set; }
        int ContentType { get; set; }
        long ContentLength { get; set; }
        byte[] Content { get; set; }
    }
}
