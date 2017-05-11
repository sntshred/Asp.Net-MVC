using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TokenAuthentication.Models;

namespace TokenAuthentication.Controllers
{
    [Authorize]
    public class EmployeeController : ApiController
    {
    public IEnumerable<tblEmployee> Get()
        {
            using (manEntities entity = new manEntities())
            {
                return entity.tblEmployees.ToList();
            }
        }

    }
}
