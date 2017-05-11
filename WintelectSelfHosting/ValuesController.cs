using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WintelectSelfHosting
{
    class ValuesController : ApiController
    {
        [Route("api/Values")]
        public string[] Get()
        {
            return new string[] { "value1", "value2", "value3" };
        }


    }
}
