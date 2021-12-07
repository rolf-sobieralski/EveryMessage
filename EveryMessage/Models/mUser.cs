using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryMessage.Models
{
    public class mUser
    {
        public string User { get; set; }
        public string KeyHash { get; set; }
        public mInfos UserInfos { get; set; }
    }
}
