using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_ReactJS.Models;
using WebAPI_ReactJS.ViewModels;

namespace WebAPI_ReactJS.Services.Abstract
{
    public interface IEmployeeServices
    {
        void AddEmployee(EmployeeViewModel empvm);
        EmployeeViewModel GetEmployeeById(int empId);
        List<EmployeeViewModel> GetAllEmployee();
        Employee UpdateEmployee(int empId, EmployeeViewModel empvm);
    }
}
