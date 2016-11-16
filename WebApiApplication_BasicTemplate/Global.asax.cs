using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebApiApplication1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
        
        protected void Application_PostAuthorizeRequest()
        {
            // Setup for use of Session - use with care - you could test for needed by using testing path  
            // HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath    gives you the path
            HttpContext.Current.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.Required);
        }

    }
}
