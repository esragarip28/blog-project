using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models.Entities.Concretes;

namespace WebProject.Models.Services.Abstracts
{
    public interface IUserService
    {

        void Register(User user);
    }
}
