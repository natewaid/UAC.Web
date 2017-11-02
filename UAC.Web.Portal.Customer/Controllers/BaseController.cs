using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UAC.Web.Entities;

namespace UAC.Web.Portal.Customer.Controllers
{
    public class BaseController : Controller
    {
        private UserManager<CustomerUser> _userManager;
        private SignInManager<CustomerUser, string> _signInManager;
        private IAuthenticationManager _authManager;

        protected UserManager<CustomerUser> UserManager
        {
            get
            {
                return _userManager ?? (_userManager = HttpContext.GetOwinContext().Get<UserManager<CustomerUser>>());
            }
        }

        protected SignInManager<CustomerUser, string> SignInManager
        {
            get
            {
                return _signInManager ?? (_signInManager = HttpContext.GetOwinContext().Get<SignInManager<CustomerUser, string>>());
            }
        }

        protected IAuthenticationManager AuthenticationManager
        {
            get
            {
                return _authManager ?? (_authManager = HttpContext.GetOwinContext().Authentication);
            }
        }

        [Route("", Name = "home")]
        public ActionResult Home()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToRoute("portal");
            }

            return RedirectToRoute("login");
        }
    }
}