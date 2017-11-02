using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UAC.Web.Portal.Customer.Models;

namespace UAC.Web.Portal.Customer.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseController
    {
        [Route("login", Name = "login")]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToRoute("portal");
            }

            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            var status = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);

            if (status == SignInStatus.Success)
            {
                return RedirectToRoute("portal");
            }

            ModelState.AddModelError("", "Invalid credentials.");

            return View(model);
        }

        [Route("logout", Name = "logout")]
        public ActionResult LogOut()
        {
            AuthenticationManager.SignOut();
            return RedirectToRoute("login");
        }
    }
}