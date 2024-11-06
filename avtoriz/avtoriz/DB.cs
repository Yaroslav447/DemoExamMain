using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace avtoriz
{
    internal class DB
    {
        MySqlConnection connection = new MySqlConnection("server=192.168.1.200;port=3306;username=stis4-01;password=dKR3&b&k9y;database=belavtoriz");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }

    }
}
