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
    public class DepartmentController : ControllerBase
    {
        private IDepartmentServices _departmentServices;

        public DepartmentController(IDepartmentServices departmentServices)
        {
            _departmentServices = departmentServices;
        }

        [HttpPost("add-deparment")]
        public IActionResult AddDepartment([FromBody] DepartmentViewModel dep)
        {
            _departmentServices.AddDepartment(dep);
            return new JsonResult("Added Successfully!");
        }

        [HttpGet("get-department-by-id/id")]
        public IActionResult GetDepartmentById(int depId)
        {
            var _dep = _departmentServices.GetDepartmentById(depId);
            return new JsonResult(_dep);
        }

        [HttpGet("get-all-department")]
        public IActionResult GetAllDepartment()
        {
            var _dep = _departmentServices.GetAllDepartment();
            return new JsonResult(_dep);
        }

        [HttpPut("update-department")]
        public IActionResult UpdateDeparment(int depId, [FromBody] DepartmentViewModel depvm)
        {
            _departmentServices.UpdateDepartment(depId, depvm);
            return new JsonResult("Updated Successfully!");
        }
    }
}
