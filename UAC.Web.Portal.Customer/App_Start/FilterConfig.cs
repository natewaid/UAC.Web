﻿using System.Web;
using System.Web.Mvc;

namespace UAC.Web.Portal.Customer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
