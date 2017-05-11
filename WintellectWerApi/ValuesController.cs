using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WintellectWerApi
{
    public class ValuesController:ApiController
    {
        [Route("api/Values")]
        public string[] Get()
        {
            return new string[] { "value1", "value2", "value3" };
        }


    }
}