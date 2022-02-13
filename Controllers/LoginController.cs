
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models.Services.Abstracts;

namespace WebProject.Controllers
{
    public class LoginController : Controller
    {

        private readonly ILoginService _loginService;
        
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
           bool result= _loginService.Login(username,password);
            if (result == true)
            {
                ViewData["session"] = "yes";
                return RedirectToAction("Dashboard", "Home");
            }
            else return RedirectToAction("Login", "Home");
        }

        public IActionResult LogOut()
        {
            _loginService.LogOut();
            return RedirectToAction("Login", "Home");

        }
             
    }
}
