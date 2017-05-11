using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace IntroducationToWebAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Values/{id:int}")]

    public class ValuesController : ApiController
    {
        static List<string> listStrings = new List<string>()
        {
            "value1","value2","value3"
        };
        //GET api/values
        public IEnumerable<string> Get()
        {
            return listStrings;
        }

        //  [ResponseType(typeof(IEnumerable<string>))]
        //public HttpResponseMessage Get()
        //{
        //    var response = Request.CreateResponse(HttpStatusCode.OK, listStrings.ToList());

        //    return response;
        //}

        // GET api/values/5

        //  [Route("api/Values/{id}/address/{type}")]
        //Route Attribut with contraints

        //[Route("address/{type:regex(home|work|shopping)}")]

        public string Get(int id, string type)
        {
            listStrings[id] = type;
            return listStrings[id];
        }
        [Route("address/{type:regex(visa|mastercard)}")]

        public string GetCutomerAddress(int id, string type)
        {
            listStrings[id] = type;
            return listStrings[id];
        }


        // POST api/values
        public IHttpActionResult Post([FromBody]string value)
        {
            listStrings.Add(value);

            return CreatedAtRoute("DefaulApi", new { id = value.ToLower() }, value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            listStrings[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            listStrings.RemoveAt(id);
        }
    }
}
