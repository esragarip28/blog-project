using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models.DataAccess.Abstracts;
using WebProject.Models.DataAccess.Concretes;
using WebProject.Models.Entities.Concretes;
using WebProject.Models.Services.Abstracts;

namespace WebProject.Models.Services.Concretes
{
    public class LoginManager : ILoginService
    {
        private readonly ILoginDal _loginDal;

        public LoginManager(ILoginDal loginDal)
        {
            _loginDal = loginDal;

        }
        public bool Login(string username, string password)
        {
          
            return _loginDal.Login(username,password);
        }

        public void LogOut()
        {
            
                SessionSingleton.instance = null;
        }
    }
}
