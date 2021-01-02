using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using DevFramework.Core.Utilities.Mvc.Infrastructure;
using DevFramework.Northwind.Business.DependencyResolvers.Ninject;

namespace DevFramework.Northwind.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));
        }
        //asp.net mvc de kullanýcý bilgiilerine eriþim ...
        public override void Init()
        {
            //bu eventi luþturcak ortam 
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init(); 
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            //kiþinin  bilgilerine eriþilebilir olduðu zamana karþýlýk gelir.
            //adým 1 : Cookie ye eriþmeye çalýþ bir cooki olluþtur.

            try
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                //kýsaca biz bu isimle bir cooki oluþturcaðýmýzý söylemiþ olduk.
                if (authCookie == null)
                {
                    return;
                }

                var encTicket = authCookie.Value;
                if (string.IsNullOrEmpty(encTicket))
                {
                    return;
                }

                var ticket = FormsAuthentication.Decrypt(encTicket);
                var securityUtilities = new SecurityUtilities();
                var identiy = securityUtilities.FormsAuthTicketToIdentity(ticket);
                var principal = new GenericPrincipal(identiy, identiy.Roles);
                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;//backend de kullansýn diye
            }
            catch (Exception )
            {
          
            }
          
        }
    }
}
