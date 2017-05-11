using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace IntroducationToWebAPI
{
    public class RequireHttpsAttribute:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Found);
                actionContext.Response.Content = new StringContent("<p>Use HTTPS insetad of HTTP </p>");
                UriBuilder uribuilder = new UriBuilder(actionContext.Request.RequestUri);
                uribuilder.Scheme = Uri.UriSchemeHttps;
                uribuilder.Port = 44332;
                actionContext.Response.Headers.Location = uribuilder.Uri;
            }
            {
                base.OnAuthorization(actionContext);
            }
        }

    }
}