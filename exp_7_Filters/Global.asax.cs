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

        // A�a��dakiler sonradan eklendi
        protected void Application_End()
        {
           // instance ramden silindi�i zaman otomatik �al���r. debug�n� yapamad�k o y�zden.
        }

        protected void Application_Error()
        {
            //hata y�netimini ister burdan ister filter ile yapabilrisiniz. exceptionhandled true i�aretleyince filter �al���r bura �al��maz.
        }

        protected void Session_Start()
        {
            // kullan�c� siteye istekte bulundu�unda buras� tetiklenir. 

            Application.Lock(); // birden fazla kullan�c� istek att���nda birinin i�i bitmeden di�er ki�iye ge�mesin diye
            var tzs = Application["ToplamZiyaretciSayisi"];
                if (tzs != null)
            {
                var intTzs = Convert.ToInt32(tzs);
                Application["ToplamZiyaretciSayisi"] = intTzs + 1; // (intTzs++ olmaz! artt�rma i�lemini atad�ktan sonra yap�yor ��nk� bu )
            }

            var ozs = Application["OnlineZiyaretciSayisi"];
            if (ozs != null)
            {
                var intOzs = Convert.ToInt32(ozs);
                Application["OnlineZiyaretciSayisi"] = intOzs + 1; // (intTzs++ olmaz! artt�rma i�lemini atad�ktan sonra yap�yor ��nk� bu )
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
                Application["OnlineZiyaretciSayisi"] = intOzs - 1; // (intTzs++ olmaz! artt�rma i�lemini atad�ktan sonra yap�yor ��nk� bu )
            }

            Application.UnLock();

        }
    }
}
