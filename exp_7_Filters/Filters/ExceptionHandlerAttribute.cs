using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace exp_7_Filters.Filters
{
    public class ExceptionHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext) // index sayfasında hata fırlattığı için, OnException metodu tetiklendi.
        {
            var controllerAdi = filterContext.RouteData.Values["controller"];
            var actionAdi = filterContext.RouteData.Values["action"];

            // bu hatanın db veya bir file'a loglanması gerekir.


            filterContext.Controller.TempData["HataMesaji"] = filterContext.Exception.Message; // sistemdeki hatayı error sayfasında göstermek istiyosan. tempdatayı burda setledik.

            filterContext.ExceptionHandled = true;

            //filterContext.HttpContext.Response.RedirectToRoute(new RouteValueDictionary(new { conroller = "home", action = "error" }));



            filterContext.HttpContext.Response.Redirect("/home/error");

        }
    }
}