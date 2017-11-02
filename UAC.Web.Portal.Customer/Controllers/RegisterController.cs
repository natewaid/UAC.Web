using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UAC.Web.Entities;
using UAC.Web.Portal.Customer.Models;

namespace UAC.Web.Portal.Customer.Controllers
{
    public class RegisterController : BaseController
    {
        [Route("register", Name = "register")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            var user = await UserManager.FindByNameAsync(model.Username);

            if (user != null)
            {
                return RedirectToRoute("login");
            }            

            var result = await UserManager.CreateAsync(new CustomerUser
            {
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            }
            , model.Password);

            if (result.Succeeded)
            {
                return RedirectToRoute("login");
            }

            ModelState.AddModelError("", result.Errors.FirstOrDefault());

            return View(model);
        }
    }
}