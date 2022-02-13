using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models.Entities.Concretes
{
    public class User
    {
        private int userId;
        private string fullName;
        private string username;
        private string password;
        private int birthYear;
        private string email;

        public User(int userId, string fullName, string username, string password, int birthYear, string email)
        {
            this.userId = userId;
            this.fullName = fullName;
            this.username = username;
            this.password = password;
            this.birthYear = birthYear;
            this.email = email;
        }
        public User() { }

        public int UserId { get => userId; set => userId = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int BirthYear { get => birthYear; set => birthYear = value; }
        public string Email { get => email; set => email = value; }
    }
}
