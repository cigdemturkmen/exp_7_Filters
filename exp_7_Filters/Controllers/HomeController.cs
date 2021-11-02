using exp_7_Filters.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exp_7_Filters.Controllers
{
    [Log]
    [ExceptionHandler]
    public class HomeController : Controller
    {
        /*
         Filters : aspect oriented. bir şeyi çağırmasan da olay gerçekleştiğinde otomatik olarak o işlemlerin tetiklenmesi olayı. bir kez tanımlanır. (mülakat sorusu)

        1.ActionFilter :
          a. OnActionExecuting: action'a girilmeden hemen önce çalışır.
          b. OnActionExecuted : Action'dan çıkıldıktan sonra çalışır.
        2.ResultFilter :
          a. Onresultexecuting : Sonuç döndürülmeden önce çalışır
          b. OnResultExecuted : Sonuç döndürüldükten sonra çalışır
        3.Exceptionfilter :

        4.AuthorizationFilter:
         */

        /*[Log]*/
        public ActionResult Index()
        {
            throw new Exception("Hatasız action olmaz!");
            return View();
        }


        /*[Log]*/ // Bu controller'daki tüm action2lara etki etmesini istiyosan public class HomeController'ın üstüne yapıştır
        public ActionResult List()
        {
            return View();
        }


        public ActionResult Error()
        {
            var mesaj = TempData["HataMesaji"];

            return View();
        }
    }
}