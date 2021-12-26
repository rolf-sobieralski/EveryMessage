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
        public string pass { get; set; }
        public string LastIp { get; set; }
        public string SessionHash { get; set; }
        public DateTime LastHeartBeat { get; set; }
        public EveryMessage.Classes.Enums.Status UserStatus { get; set; }
        public User(object[] objlist)
        {
            MySqlDataReader dr = (MySqlDataReader)objlist[0];
            if(!dr.IsDBNull(0))
            {
                Id = dr.GetInt32(0);
            }
            if (!dr.IsDBNull(1)){
                Username = dr.GetString(1);
            }
        }
    }

}
