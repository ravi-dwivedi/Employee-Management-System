using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Nagarro.EmployeePortal.BLL
{
    public class Department
    {
        int _departmentId;
        string _departmentName;

        public int DepartmentId
        {
            get { return _departmentId; }
        }

        public string DepartmentName
        {
            get { return _departmentName; }
        }
    }
}
