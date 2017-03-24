using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bizagi.Business.Reports
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Response.Clear();

            HttpException httpException = exception as HttpException;

            int error = httpException != null ? httpException.GetHttpCode() : 0;

            Server.ClearError();
            Response.Redirect(String.Format("~/Error/?error={0}", error, exception.Message));
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        void Application_BeginRequest(object sender, EventArgs ex)
        {
            ///* ======== For Chrome ======== */
            //Response.AddHeader("X-WebKit-CSP", "default-src 'self'; img-src *; script-src 'self'; style-src 'self' 'unsafe-inline'; report-uri /Home/Report");

            ///* ======== For Firefox ======== */
            //Response.AddHeader("X-Content-Security-Policy", "default-src 'self'; img-src *; script-src 'self'; style-src 'self' 'unsafe-inline'; report-uri /Home/Report");
            //Response.AddHeader("Content-Security-Policy", "default-src https: data: 'unsafe-inline' 'unsafe-eval'");
            //Response.AddHeader("X-WebKit-CSP", "script-src 'self'");
            //Response.AddHeader("X-Content-Security-Policy", "script-src 'self'");
        }

        
    }
}
