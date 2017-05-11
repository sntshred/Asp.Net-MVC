using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace WintelectSelfHosting
{
    class Program
    {
        static void Main(string[] args)
        {

            var config = new HttpSelfHostConfiguration("http://localhost:12345");
            config.Routes.MapHttpRoute(
                name:"DefaultApi",
                routeTemplate:"api/{controller}/{id}",
                defaults:new {id=RouteParameter.Optional}
                 );

            using (var server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Press Enter to Exit");
                Console.ReadLine();
            }
        }
    }
}
