using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exp_7_Filters.Filters
{
    public class AuthAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //session varlığı kontrol edilir.
            var currentUser = filterContext.HttpContext.Session["LoginBilgileri"];

            if (currentUser == null)
            {
                filterContext.HttpContext.Response.Redirect("/auth/login");
            }
        }
    }
}