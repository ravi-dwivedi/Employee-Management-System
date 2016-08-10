using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Nagarro.EmployeePortal.DAL
{
    public class Database
    {
        public static string EmployeePortalString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["EmployeePortalString"].ConnectionString;
            }
        }
    }
}
