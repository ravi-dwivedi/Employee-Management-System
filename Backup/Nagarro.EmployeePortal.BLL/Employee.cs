using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Nagarro.EmployeePortal.BLL
{
    public class Employee
    {
        int _employeeId;
        string _employeeCode;
        string _firstName;
        string _lastName;
        DateTime _dateOfBirth;
        string _email;
        Department _department;
        DateTime _dateOfJoining;

        public int EmployeeId
        {
            get { return _employeeId; }
        }

        public string EmployeeCode
        {
            get { return _employeeCode; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public Department Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public DateTime DateOfJoining
        {
            get { return _dateOfJoining; }
            set { _dateOfJoining = value; }
        }

        public static Employee GetEmployee(int employeeId)
        {
            Employee employee = new Employee();
            employee.Fetch(employeeId);
            return employee;
        }

        public static Employee NewEmployee(int employeeId)
        {
            Employee employee = new Employee();
            return employee;
        }

		public Employee()
        {
        }

        private void Fetch(int employeeId)
        {
          // TODO:
        }

        public void Save()
        {
            if (this._employeeId == 0)
            {
                // Means this is a new Employee record and needs
                // to be inserted into the database

                // TODO: Code to insert the employee into database
            }
            else
            {
                // Means this Employee record is already present
                // in the database and needs to be updated

                // TODO: Code to update the employee into database
            }
        }
    }
}
