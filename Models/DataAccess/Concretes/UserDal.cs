using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models.DataAccess.Abstracts;
using WebProject.Models.Entities.Concretes;

namespace WebProject.Models.DataAccess.Concretes
{
    public class UserDal : IUserDal
    {
        DbConnection connection = new DbConnection();
        public void Register(User user)
        {
            connection.ConnectDb();
            string query = "insert into users (full_name, username,password,email, birth_year) " +
               "values(@p1,@p2,@p3,@p4,@p5)";
            NpgsqlCommand cmd = new NpgsqlCommand(query, connection.connection);
            cmd.Parameters.AddWithValue("@p1", user.FullName);
            cmd.Parameters.AddWithValue("@p2", user.Username);
            cmd.Parameters.AddWithValue("@p3", user.Password);
            cmd.Parameters.AddWithValue("@p4", user.Email);
            cmd.Parameters.AddWithValue("@p5", user.BirthYear);
            cmd.ExecuteNonQuery();
            connection.CloseConnection();
        }
    }
}
