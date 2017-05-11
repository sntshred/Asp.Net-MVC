using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VersioninWebApi.Models;

namespace VersioninWebApi.Controllers
{
    public class StudentV2Controller : ApiController
    {
        List<StudentV2> obj = new List<StudentV2>()
        {
            new StudentV2() {Id=101,firsName="noha",lastname="rakli"},
            new StudentV2() {Id=102,firsName="santosh",lastname="kmk" },
            new StudentV2() {Id=103,firsName="santosh",lastname="kcgavn" }
        };

    //    [Route("api/v2/students")]

        public IEnumerable<StudentV2> GetStudents()
        {
            return obj;
        }
      //  [Route("api/v2/students/{id}")]

        public StudentV2 GetStudents(int id)
        {
            return obj.FirstOrDefault(x=>x.Id==id);
        }


    }
}
