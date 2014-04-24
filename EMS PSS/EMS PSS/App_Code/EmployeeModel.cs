using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMS_PSS.App_Code
{
    public class EmployeeModel
    {

        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            Employee bob = new Employee();

            bob.FirstName = "Bob";
            employees.Add(bob);

            return employees;
        }
    }
}