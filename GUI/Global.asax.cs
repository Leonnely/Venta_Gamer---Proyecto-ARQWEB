using GUI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication1
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //void Application_AuthenticateRequest(Object sender, EventArgs e)
        //{
        //    // Verifica si HttpContext y User no son nulos
        //    if (HttpContext.Current != null && HttpContext.Current.User != null)
        //    {
        //        // Verifica si el usuario no está autenticado y si la solicitud no es para la página de login
        //        if (!HttpContext.Current.User.Identity.IsAuthenticated &&
        //            !HttpContext.Current.Request.Url.AbsolutePath.EndsWith("/WebForms/Session/login.aspx"))
        //        {
        //            HttpContext.Current.Response.Redirect("~/WebForms/Session/login.aspx");
        //        }
        //    }
        //}
    }
}