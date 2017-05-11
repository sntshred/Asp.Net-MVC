using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntroducationToWebAPI
{
    public class EmployeeSecurity
    {
        public static bool Login(string username, string password)
        {
            using(EmployeeDataAccess.EmployeeDBEntities entit = new EmployeeDataAccess.EmployeeDBEntities())
            {
                return entit.Users.Any(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)&& user.Password==password);
            }
        }

    }
}