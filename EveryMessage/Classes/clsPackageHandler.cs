using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryMessage.Classes
{
    public class clsPackageHandler
    {
        public clsPackageHandler()
        {

        }

        public EveryMessage.Models.mPackage CreatePackage()
        {
            return new Models.mPackage();
        }
    }
}
