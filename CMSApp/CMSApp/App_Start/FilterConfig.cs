﻿using CMSApp.ExceptionLogger;
using System.Web;
using System.Web.Mvc;

namespace CMSApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
