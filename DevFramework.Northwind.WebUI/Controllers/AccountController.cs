using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using DevFramework.Northwind.Business.Abstract;

namespace DevFramework.Northwind.WebUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public string Login(string username, string password)
        {
            var user = _userService.GetByUserNameAndPassword(username, password);
            if (user!=null)
            {
                AuthenticationHelper.CreateAuthCookie(new Guid(), user.UserName,
                    user.Email,
                    DateTime.Now.AddDays(15),
                    new[] { "Admin" },
                    false,
                    user.FirstName,
                    user.LastName
                );
                return "User is authenticated";
            }

            return "User is NOT authenticated";


        }
        
    }
}