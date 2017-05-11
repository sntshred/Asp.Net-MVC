using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VersioninWebApi.Models;

namespace VersioninWebApi.Controllers
{
    public class StudentV1Controller : ApiController
    {
        List<StudentV1> obj = new List<StudentV1>()
        {
            new StudentV1() {Id=101,Name="santosh" },
            new StudentV1() {Id=101,Name="santosh" },
            new StudentV1() {Id=101,Name="santosh" },
            new StudentV1() {Id=101,Name="santosh" },
            new StudentV1() {Id=101,Name="santosh" }
        };

    //    [Route("api/v1/students")]
        public IEnumerable<StudentV1> GetStudents()
        {
            return obj;
        }
       // [Route("api/v1/students/{id}")]

        public StudentV1 GetStudents(int id)
        {
            return obj.FirstOrDefault(x=>x.Id==id);
        }


    }
}
