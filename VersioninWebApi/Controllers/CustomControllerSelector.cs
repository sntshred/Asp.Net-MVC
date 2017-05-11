using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace VersioninWebApi.Controllers
{
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        private HttpConfiguration _configuration;

        public CustomControllerSelector(HttpConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var controllers= GetControllerMapping();
            var routedata = request.GetRouteData();
            var contrllername = routedata.Values["controller"].ToString();

            string version = "1";
            var vesionquerystring = HttpUtility.ParseQueryString(request.RequestUri.Query);
            if(vesionquerystring["v"] != null){
                version = vesionquerystring["v"];
            }

            if (version == "1")
            {
                contrllername = contrllername + "V1";
            }
            else
            {
                contrllername = contrllername + "V2";

            }

            request.Headers.Accept.Where(a => a.Parameters.Count(x=>x.Name=="ok") > 0);

            HttpControllerDescriptor controllerDescriptor;
           if(controllers.TryGetValue("contrllername", out controllerDescriptor))
            {
                return controllerDescriptor;
            }
            return null;
            



        }



    }
}
