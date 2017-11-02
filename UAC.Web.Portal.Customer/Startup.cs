using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using UAC.Web.Entities;

[assembly: OwinStartup(typeof(UAC.Web.Portal.Customer.Startup))]

namespace UAC.Web.Portal.Customer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var connStr = ConfigurationManager.ConnectionStrings["account"].ConnectionString;

            app.CreatePerOwinContext(() => new CustomerUserDbContext(connStr));

            app.CreatePerOwinContext<UserStore<CustomerUser>>(
                (options, context) => new UserStore<CustomerUser>(context.Get<CustomerUserDbContext>()));

            app.CreatePerOwinContext<UserManager<CustomerUser>>(
                (options, context) => new UserManager<CustomerUser>(context.Get<UserStore<CustomerUser>>()));

            app.CreatePerOwinContext<SignInManager<CustomerUser, string>>(
                (options, context) => new SignInManager<CustomerUser, string>(context.Get<UserManager<CustomerUser>>(), context.Authentication));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {                
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
        }
    }
}