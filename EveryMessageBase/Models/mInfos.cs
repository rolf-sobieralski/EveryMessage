using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryMessageBase.Models
{
    public class mInfos
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool AddressVisible { get; set; }
        public string StreetName { get; set; }
        public long StreetNumber { get; set; }
        public string NumberAddition { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Land { get; set; }
        public string Mail { get; set; }
        public List<mPhoneNumber> PhoneNumbers { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
