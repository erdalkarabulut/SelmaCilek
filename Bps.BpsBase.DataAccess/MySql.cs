using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.DataAccess
{
    public class MySql
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string port;

        public MySql()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "192.168.1.123";
            database = "starkom";
            uid = "root";
            password = "max";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=3306;" + "DATABASE=" +
                               database + ";" + "uid=" + uid + ";" + "pwd=" + password + ";SslMode=None";

            connection = new MySqlConnection(connectionString);
        }

        public string OpenConnection()
        {
            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        return "Cannot connect to server.  Contact administrator";
                    case 1045:
                        return "Invalid username/password, please try again";
                }

                return ex.ToString();
            }
            return "";
        }

        //Close connection
        private string CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }

            return "";
        }

        //public List<string>[] Select()
        //{
        //}


    }
}
