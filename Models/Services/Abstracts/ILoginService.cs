using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models.Services.Abstracts
{
    public interface ILoginService
    {
        bool Login(string username, string password);

        void LogOut();
    }
}
