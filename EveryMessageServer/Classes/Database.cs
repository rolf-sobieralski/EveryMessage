﻿using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EveryMessageServer.Classes
{
    public class Database
    {
        private string _Salt = "";
        private string _IPAddress = "";
        private string _Port = "";
        private string _Username = "";
        private string _Pass = "";
        private string _Db = "";
        public Database()
        {
                var SettingsList = ConfigurationManager.AppSettings;
            _IPAddress = SettingsList["DatabaseIPAddress"];
            _Port = SettingsList["DatabasePort"];
            _Username = SettingsList["DatabaseUser"];
            _Pass = SettingsList["DatabasePassword"];
            _Db = SettingsList["Database"];
            _Salt = SettingsList["PasswordSalt"];
        }

        private MySqlConnection GetConnection(ref Exception Ex)
        {
            MySqlConnection Con = null;
            try
            { 
                Con = new MySqlConnection("Server = " + _IPAddress + "; Port = " + _Port + "; Database = " + _Db +" ; Uid = " + _Username + "; Pwd = " + _Pass);
                Con.Open();
                if (Con.State != System.Data.ConnectionState.Open)
                {
                    Exception ex = new Exception("Fehler beim Versuch eine Datenbankverbindung her zu stellen");
                    Ex = ex;
                }
            }catch(Exception ex)
            {
                Ex = ex;
            }
            return Con;
        }

        public T GetInstanceFromReader<T>(MySqlDataReader reader)
        {

            return (T)typeof(T).GetConstructor(new Type[] { typeof(T) }).Invoke(new object[] { reader },null);
        }
        public EveryMessageServer.Models.User GetUser(string user, string hash, ref Exception ex)
        {
            MySqlConnection Con = GetConnection(ref ex);
            Models.User ReturnUser = null;
            try
            {
                MySqlCommand Command = new MySqlCommand();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT");
                sb.AppendLine("     Id,");
                sb.AppendLine("     Username,");
                sb.AppendLine("     Password,");
                sb.AppendLine("     SessionHash,");
                sb.AppendLine("     LastIPEndPoint,");
                sb.AppendLine("     LastHeartBeat,");
                sb.AppendLine("     Status");
                sb.AppendLine("FROM");
                sb.AppendLine("     Users");
                sb.AppendLine("WHERE");
                sb.AppendLine("     Username=@UserName");
                sb.AppendLine("AND");
                sb.AppendLine("     Password=@Password");
                Command.CommandText = sb.ToString();
                Command.Parameters.AddWithValue("@UserName", user);
                Command.Parameters.AddWithValue("@Password", hash);
                Command.Connection = Con;
                MySqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    ReturnUser = GetInstanceFromReader<Models.User>(reader);
                }
            }catch(Exception UserException)
            {
                Exception newException = new Exception("GetUser hat eine Ausnahme ausgelöst", UserException);
                ex = newException;
            }
            if(ReturnUser != null)
            {
                return ReturnUser;
            }
            return null;
        }
    }
}
