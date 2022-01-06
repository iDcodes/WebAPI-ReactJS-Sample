using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_ReactJS.Models;
using WebAPI_ReactJS.Services.Abstract;
using WebAPI_ReactJS.ViewModels;

namespace WebAPI_ReactJS.Services.Implementation
{
    public class EmployeeServices : IEmployeeServices
    {
        private AppDbContext _db;

        public EmployeeServices(AppDbContext db)
        {
            _db = db;
        }

        public void AddEmployee(EmployeeViewModel empvm)
        {
            var _emp = new Employee()
            {
                Name = empvm.EmployeeName,
                PhotoFileName = empvm.PhotoFileName,
                DateEntered = empvm.DateEntered,
                DateCreated = DateTime.Now,
                DepartmentId = empvm.DepartmentId
            };

            _db.Employees.Add(_emp);
            _db.SaveChanges();
        }

        public EmployeeViewModel GetEmployeeById(int empId)
        {
            var _emp = _db.Employees
                .Where(d => d.Id == empId)
                .Select(e => new EmployeeViewModel()
                {
                    EmployeeName = e.Name,
                    PhotoFileName = e.PhotoFileName,
                    DateEntered = (DateTime)e.DateEntered,
                    DateCreated = (DateTime)e.DateCreated,
                    DateModified = (DateTime)e.DateModified,
                    Departments = new Department()
                    {
                        Id = e.Departments.Id,
                        Name = e.Departments.Name
                    }
                })
                .FirstOrDefault();

            return _emp;
        }

        public List<EmployeeViewModel> GetAllEmployee()
        {
            var _emp = _db.Employees
                .Select(e => new EmployeeViewModel()
                {
                    EmployeeName = e.Name,
                    PhotoFileName = e.PhotoFileName,
                    DateEntered = e.DateEntered,
                    DateCreated = e.DateCreated,
                    DateModified = e.DateModified,
                    Departments = new Department()
                    {
                        Id = e.Departments.Id,
                        Name = e.Departments.Name
                    }
                })
                .ToList();

            return _emp;
        }

        public Employee UpdateEmployee(int empId, EmployeeViewModel empvm)
        {
            var _emp = _db.Employees.FirstOrDefault(d => d.Id == empId);

            _emp.Name = empvm.EmployeeName;
            _emp.PhotoFileName = empvm.PhotoFileName;
            _emp.DateEntered = empvm.DateEntered;
            _emp.DateModified = DateTime.Now;
            _emp.DepartmentId = empvm.DepartmentId;

            _db.SaveChanges();

            return _emp;
        }
    }
}
