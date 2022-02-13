using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models.DataAccess.Abstracts;
using WebProject.Models.Entities.Concretes;
using WebProject.Models.Services.Abstracts;

namespace WebProject.Models.Services.Concretes
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Register([FromBody]User user)
        {
            _userDal.Register(user);

        }
    }
}
