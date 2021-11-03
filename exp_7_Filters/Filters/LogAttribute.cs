using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exp_7_Filters.Filters
{
    public class LogAttribute : FilterAttribute, IActionFilter, IResultFilter
    {
        
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //1. çalışır: action'a henüz girilmemişken.
        }

        
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // 2. çalışır: action'dan çıkıldığı zaman.
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            // 3. çalışır: List.cshtml'e gitmeden önce...
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
           // 4. çalışır: List.cshtml'den çıktıktan sonra sayfa açılmadan önce burası çalışır.
        }
    }
}