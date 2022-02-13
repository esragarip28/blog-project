using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models.DataAccess.Concretes
{
    public class DbConnection
    {
        public NpgsqlConnection connection;
        public DbConnection()
        {
            connection = new NpgsqlConnection(
                "server=localhost;port =5432; Database=bpdb; username=postgres; password=190533esra"
                );
        }

        public void ConnectDb()
        {   
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }
    }
}
