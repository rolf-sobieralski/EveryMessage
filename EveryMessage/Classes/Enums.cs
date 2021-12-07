using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryMessage.Classes
{
    public class Enums
    {
        public enum PhoneNumberType : int
        {
            Unknown = 0,
            Mobile = 1,
            PrivatePhone = 2,
            OfficePhone = 3

        }
        public enum Status : int
        {
            Offline = 0,
            Online = 1,
            Invisible = 2,
            Away = 3,
            DoNotDisturb = 4
        }

        public enum LoginStep :int
        {
            Hello = 0,
            LoginChalange = 1,
            LoginResonse = 2,
        }
        public enum ResponseCode : int
        {
            Error = 0,
            OK = 1,
            ACK = 2,
            Abort = 3,
            Read = 4,
            Status = 5,
            StatusRequest = 6,
            StatusResponse = 7,
            Logout = 8
        }
        public enum RequestCode : int
        {
            Error = 0,
            OK = 1,
            ACK = 2,
            Abort = 3,
            Resend = 4,
            Status = 5,
            Info = 6,
            Details = 7
        }
    }
}
