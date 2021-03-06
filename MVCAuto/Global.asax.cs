using MVCAuto.Monitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
//This will set register method to be called before Application_Start
[assembly: PreApplicationStartMethod(typeof(MVCAuto.MvcApplication), "Register")]

namespace MVCAuto
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void Register()
        {
            HttpApplication.RegisterModule(typeof(ModuleExampleTestCS));
            HttpApplication.RegisterModule(typeof(LoginModule));
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //WebApi
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
           // if (Context.Handler is IRequiresSessionState || Context.Handler is IReadOnlySessionState)
           // {
                //HttpContext context = HttpContext.Current;
                // Your Methods
           // }
        }

        //protected void Application_PostAuthorizeRequest()
        //{
        //    HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
        //}



    }
}
