using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models.DataAccess.Abstracts
{
    public interface ILoginDal
    {
        bool Login(string username, string password);



    }
}
