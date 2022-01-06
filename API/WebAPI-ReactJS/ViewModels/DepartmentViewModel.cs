using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_ReactJS.Models;

namespace WebAPI_ReactJS.ViewModels
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        //Employee
        public DepartmentEmployee DepartmentEmployees;
    }

    public class DepartmentEmployee
    {
        public List<int> EmployeeId { get; set; }
        public List<string> EmployeesName { get; set; }
    }
}
