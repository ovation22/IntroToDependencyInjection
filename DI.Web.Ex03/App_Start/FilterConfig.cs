﻿using System.Web;
using System.Web.Mvc;

namespace DI.Web.Ex03
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
