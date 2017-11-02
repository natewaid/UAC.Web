using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UAC.Web.Portal.Customer.Controllers
{
    public class PortalController : BaseController
    {
        [Authorize]
        [Route("portal", Name = "portal")]
        public ActionResult Index()
        {
            return View();
        }
    }
}