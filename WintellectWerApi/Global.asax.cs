using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace WintellectWerApi
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Debug.Print("Application_Start");
            //GlobalConfiguration.Configure(
            //    c => c.MapHttpAttributeRoutes()
            //    );

            GlobalConfiguration.Configure(
             config => {
                 config.MapHttpAttributeRoutes();
                 config.Formatters.Remove(config.Formatters.XmlFormatter);
             }
             );
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Debug.Print("Session_Start");

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Debug.Print("Application_BeginRequest");

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            Debug.Print("Application_AuthenticateRequest");

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Debug.Print("Application_Error");

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}