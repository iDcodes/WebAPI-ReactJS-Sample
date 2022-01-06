using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_ReactJS.Models;

namespace WebAPI_ReactJS.ViewModels
{
    public class EmployeeViewModel
    {
        public string EmployeeName { get; set; }
        public string PhotoFileName { get; set; }
        public DateTime? DateEntered { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        //Department Props
        public int DepartmentId { get; set; }
        public Department Departments;
    }

}
