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
         Filters : aspect oriented: bir metodu çağırmasan da olay gerçekleştiğinde otomatik olarak o işlemlerin tetiklenmesi olayı. bir kez tanımlanır hep çalışır. (mülakat sorusu)

        1.ActionFilter :
          a. OnActionExecuting: Action'a girilmeden hemen önce çalışır.
          b. OnActionExecuted : Action'dan çıkıldıktan sonra çalışır.
        2.ResultFilter :
          a. Onresultexecuting : Sonuç döndürülmeden önce çalışır.
          b. OnResultExecuted : Sonuç döndürüldükten sonra çalışır.
        3.Exceptionfilter : Bir hata olduğu zaman OnException metodu tetiklenir.

        4.AuthorizationFilter: hocaya tempdatanın mesajını atamadık onu sor?

         */

        // [Log]
        public ActionResult Index()
        {
            throw new Exception("Hatasız action olmaz! :D");
            return View();
        }


        // [Log] -- Bu controller'daki tüm action'lara etki etmesini istiyosan public class HomeController'ın üstüne yapıştır.
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