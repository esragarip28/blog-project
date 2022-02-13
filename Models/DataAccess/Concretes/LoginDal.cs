
using Microsoft.AspNetCore.Http;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebProject.Models.DataAccess.Abstracts;

namespace WebProject.Models.DataAccess.Concretes
{
    public class LoginDal : ILoginDal
    {
        DbConnection connection = new DbConnection();

        public bool Login(string username, string password)
        {
            connection.ConnectDb();
            string query = "Select * from users where username=@username and password=@password ";
            var cmd = new NpgsqlCommand(query, connection.connection);
            cmd.Parameters.Add(new NpgsqlParameter("@username", NpgsqlDbType.Text));
            cmd.Parameters["@username"].Value = username;
            cmd.Parameters.Add(new NpgsqlParameter("@password", NpgsqlDbType.Text));
            cmd.Parameters["@password"].Value = password;
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read()) {
                    SessionSingleton.GetInstance()._session.SetInt32("userId", int.Parse(reader["user_id"].ToString()));
                    SessionSingleton.GetInstance()._session.SetString("author",reader["full_name"].ToString());
                }   
                return true;
            }
            else return false;

        }

    }
}