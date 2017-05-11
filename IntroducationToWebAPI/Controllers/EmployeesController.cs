using EmployeeDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.OData;


using System.Web.Http.Cors;


namespace IntroducationToWebAPI.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]


    [Queryable]
    public class EmployeesController : ApiController
    {

        public IQueryable<tblEmployee> Get()
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.tblEmployees.ToList().AsQueryable();
            }
        }


        ////Query String Parameter

        // [BasicAuthenticationC]

        ////If you want to see the all the data, comment this fillter [basicauthenitaionc], dothe changes in juery
        //public HttpResponseMessage Get(string gender = "All")
        //{
        //    using (EmployeeDBEntities entities = new EmployeeDBEntities())
        //    {
        //        switch (gender.ToLower())
        //        {
        //            case "all":
        //                return Request.CreateResponse(HttpStatusCode.OK, entities.tblEmployees.ToList());
        //        }

        //        string username = Thread.CurrentPrincipal.Identity.Name;
        //        switch (username.ToLower())
        //        {
        //            case "all":
        //                return Request.CreateResponse(HttpStatusCode.OK, entities.tblEmployees.ToList());

        //            case "male":
        //                return Request.CreateResponse(HttpStatusCode.OK, entities.tblEmployees.Where(e => e.Gender.ToLower() == "male").ToList());

        //            case "female":
        //                return Request.CreateResponse(HttpStatusCode.OK, entities.tblEmployees.Where(e => e.Gender.ToLower() == "female").ToList());

        //            default:
        //                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Value for gender must be all Male or Female" + gender + "Is valid");
        //        }
        //    }
        //}


        //To show in the fiddler the response code, we use httpresonsemessage
        [EnableCorsAttribute("*", "*", "*")]

        public HttpResponseMessage Get(int id)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                var ent = entities.tblEmployees.FirstOrDefault(x => x.Id == id);
                if (ent != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ent);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Employee with" + id.ToString() + "not available");
                }
            }
        }

        //public HttpResponseMessage Post([FromBody]tblEmployee obj)
        //{
        //    try
        //    {
        //        using (EmployeeDBEntities entities = new EmployeeDBEntities())
        //        {
        //            entities.tblEmployees.Add(obj);
        //            entities.SaveChanges();
        //            var message = Request.CreateResponse(HttpStatusCode.Created, obj);
        //            message.Headers.Location = new Uri(Request.RequestUri + obj.Id.ToString());
        //            return message;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

        //using Ihttpactionresult

        public IHttpActionResult Post([FromBody]tblEmployee obj)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    entities.tblEmployees.Add(obj);
                    entities.SaveChanges();
                    //var message = Request.CreateResponse(HttpStatusCode.Created, obj);
                    //message.Headers.Location = new Uri(Request.RequestUri + obj.Id.ToString());
                    //return message;
                    var response = CreatedAtRoute("DefaultApi", new { id = obj.Id }, obj);
                    return response;
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request detected");
            }



            //[DisableCors]
            //public HttpResponseMessage Delete(int id)
            //{
            //    try
            //    {
            //        using (EmployeeDBEntities entity = new EmployeeDBEntities())
            //        {
            //            var ent = entity.tblEmployees.FirstOrDefault(x => x.Id == id);
            //            if (ent != null)
            //            {
            //                entity.tblEmployees.Remove(ent);
            //                entity.SaveChanges();
            //                return Request.CreateResponse(HttpStatusCode.OK);
            //            }
            //            else
            //            {
            //                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "EMployee with ID = " + id.ToString() + "for Deletion Not Found");
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            //    }
            //}

            ////public HttpResponseMessage Put(int id,[FromBody]tblEmployee empl)
            ////{
            ////    using (EmployeeDBEntities entity = new EmployeeDBEntities())
            ////    {
            ////        var x =entity.tblEmployees.FirstOrDefault(xz => xz.Id == id);
            ////        if (x == null)
            ////        {
            ////            return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with Id " + id + " Not Found");
            ////        }
            ////        if(x!=null) {
            ////            x.Name = empl.Name;
            ////            x.Gender = empl.Gender;
            ////            x.DateOfBirth = empl.DateOfBirth;
            ////            x.City = empl.City;
            ////            entity.SaveChanges();
            ////            return Request.CreateResponse(HttpStatusCode.OK);
            ////        }
            ////        return Request.CreateResponse(HttpStatusCode.BadRequest);
            ////    }
            ////}

            ////FromBody and from uri for put method/ changing the convention

            //public HttpResponseMessage Put([FromBody]int id, [FromUri]tblEmployee empl)
            //{
            //    using (EmployeeDBEntities entity = new EmployeeDBEntities())
            //    {
            //        var x = entity.tblEmployees.FirstOrDefault(xz => xz.Id == id);
            //        if (x == null)
            //        {
            //            return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with Id " + id + " Not Found");
            //        }
            //        if (x != null)
            //        {
            //            x.Name = empl.Name;
            //            x.Gender = empl.Gender;
            //            x.DateOfBirth = empl.DateOfBirth;
            //            x.City = empl.City;
            //            entity.SaveChanges();
            //            return Request.CreateResponse(HttpStatusCode.OK);
            //        }
            //        return Request.CreateResponse(HttpStatusCode.BadRequest);
            //    }
            //}

            //Custom method names
            //[HttpGet]
            //public IEnumerable<tblEmployee> LoadEmployee()
            //{
            //    using (EmployeeDBEntities entities = new EmployeeDBEntities())
            //    {
            //        return entities.tblEmployees.ToList();
            //    }
            //}

        }



    }
}