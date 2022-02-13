using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models.Entities.Concretes;

namespace WebProject.Models.DataAccess.Abstracts
{
    public interface IUserDal
    {
        void Register(User user);
    }

}
