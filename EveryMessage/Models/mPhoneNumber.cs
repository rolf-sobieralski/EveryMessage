using EveryMessage.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryMessage.Models
{
    public class mPhoneNumber
    {
        public Enums.PhoneNumberType NumberType { get; set; }
        public string CountryPreDial { get; set; }
        public string Number { get; set; }
    }
}
