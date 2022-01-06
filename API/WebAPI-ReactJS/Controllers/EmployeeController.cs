using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_ReactJS.Services.Abstract;
using WebAPI_ReactJS.ViewModels;

namespace WebAPI_ReactJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeServices _employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpPost("add-employee")]
        public IActionResult AddEmployee([FromBody] EmployeeViewModel empvm)
        {
            _employeeServices.AddEmployee(empvm);
            return new JsonResult("Added Successfully!");
        }

        [HttpGet("get-employee-by-id/id")]
        public IActionResult GetEmployeeById(int empId)
        {
            var _emp = _employeeServices.GetEmployeeById(empId);
            return new JsonResult(_emp);
        }

        [HttpGet("get-all-employee")]
        public IActionResult GetAllEmployee()
        {
            var _emp = _employeeServices.GetAllEmployee();
            return new JsonResult(_emp);
        }

        [HttpPut("update-employee")]
        public IActionResult UpdateEmployee(int empId, [FromBody] EmployeeViewModel empvm)
        {
            _employeeServices.UpdateEmployee(empId, empvm);
            return new JsonResult("Updated Successfully!");
        }
    }
}
