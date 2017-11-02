using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UAC.Web.Portal.Customer.Controllers
{
    public class RfqController : BaseController
    {
        [Route("rfq", Name = "rfq.request")]
        public ActionResult RfqRequest()
        {
            return View();
        }
    }
}