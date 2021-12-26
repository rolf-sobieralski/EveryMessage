using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EveryMessageServer.Models
{
    public class UserList:IEnumerable
    {
        private List<User> UList = new List<User>();
        public IEnumerator GetEnumerator()
        {
            return UList.GetEnumerator();
        }
        public User First()
        {
            if (((List<User>)UList).Count > 0)
            {
                return ((List<User>)UList)[0];
            }
            else
            {
                return null;
            }
        }
        
    }
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string LastIP { get; set; }
        public string SessionHash { get; set; }
        public DateTime? LastHeartBeat { get; set; }
        public int Status { get; set; }
        public EveryMessageBase.Classes.Enums.Status UserStatus
        {
            get
            {
                return (EveryMessageBase.Classes.Enums.Status)Enum.Parse(typeof(EveryMessageBase.Classes.Enums.Status), Status.ToString());
            }
        }
        public User()
        {

        }
    }

}
