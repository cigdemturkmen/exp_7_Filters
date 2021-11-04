using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace exp_7_Filters
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Application.Add("ToplamZiyaretciSayisi", 0);
            Application.Add("OnlineZiyaretciSayisi", 0);
        }

        // Aþaðýdakiler sonradan eklendi
        protected void Application_End()
        {
           // instance ramden silindiði zaman otomatik çalýþýr. debugýný yapamadýk o yüzden.
        }

        protected void Application_Error()
        {
            //hata yönetimini ister burdan ister filter ile yapabilrisiniz. exceptionhandled true iþaretleyince filter çalýþýr bura çalýþmaz.
        }

        protected void Session_Start()
        {
            // kullanýcý siteye istekte bulunduðunda burasý tetiklenir. 

            Application.Lock(); // birden fazla kullanýcý istek attýðýnda birinin iþi bitmeden diðer kiþiye geçmesin diye
            var tzs = Application["ToplamZiyaretciSayisi"];
                if (tzs != null)
            {
                var intTzs = Convert.ToInt32(tzs);
                Application["ToplamZiyaretciSayisi"] = intTzs + 1; // (intTzs++ olmaz! arttýrma iþlemini atadýktan sonra yapýyor çünkü bu )
            }

            var ozs = Application["OnlineZiyaretciSayisi"];
            if (ozs != null)
            {
                var intOzs = Convert.ToInt32(ozs);
                Application["OnlineZiyaretciSayisi"] = intOzs + 1; // (intTzs++ olmaz! arttýrma iþlemini atadýktan sonra yapýyor çünkü bu )
            }
            Application.UnLock();
        }

        protected void Session_End()
        {
            Application.Lock();

            var ozs = Application["OnlineZiyaretciSayisi"];
            if (ozs != null)
            {
                var intOzs = Convert.ToInt32(ozs);
                Application["OnlineZiyaretciSayisi"] = intOzs - 1; // (intTzs++ olmaz! arttýrma iþlemini atadýktan sonra yapýyor çünkü bu )
            }

            Application.UnLock();

        }
    }
}
