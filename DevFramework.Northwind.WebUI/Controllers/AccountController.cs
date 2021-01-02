using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFramework.Core.CrossCuttingConcerns.Security.Web;

namespace DevFramework.Northwind.WebUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public string Login()
        {
            AuthenticationHelper.CreateAuthCookie(new Guid(),"deryaunver","dryunver94qgmail.com",DateTime.Now.AddDays(15),new []{"Admin"},false,"Derya","Ünver"  );
            return "User is authenticated";
        }
    }
}