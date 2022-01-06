using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_ReactJS.Models;
using WebAPI_ReactJS.Services.Abstract;
using WebAPI_ReactJS.ViewModels;

namespace WebAPI_ReactJS.Services.Implementation
{
    public class DepartmentServices : IDepartmentServices
    {
        private AppDbContext _db;

        public DepartmentServices(AppDbContext db)
        {
            _db = db;
        }

        public void AddDepartment(DepartmentViewModel depvm)
        {
            var _dep = new Department()
            {
                Name = depvm.DepartmentName
            };

            _db.Departments.Add(_dep);
            _db.SaveChanges();
        }

        public DepartmentViewModel GetDepartmentById(int depId)
        {
            var _dep = _db.Departments
                .Where(d => d.Id == depId)
                .Select(d => new DepartmentViewModel()
                {
                    DepartmentId = d.Id,
                    DepartmentName = d.Name,
                    DepartmentEmployees = new DepartmentEmployee()
                    {
                        EmployeeId = d.Employees.Select(e => e.Id).ToList(),
                        EmployeesName = d.Employees.Select(e => e.Name).ToList()
                    }
                })
                .FirstOrDefault();

            return _dep;
        }

        public List<DepartmentViewModel> GetAllDepartment()
        {
            return _db.Departments
                .Select(d => new DepartmentViewModel()
                {
                    DepartmentId = d.Id,
                    DepartmentName = d.Name,
                    DepartmentEmployees = new DepartmentEmployee()
                    {
                        EmployeeId = d.Employees.Select(e => e.Id).ToList(),
                        EmployeesName = d.Employees.Select(e => e.Name).ToList()
                    }
                })
                .ToList();
        }

        public Department UpdateDepartment(int depId, DepartmentViewModel depvm)
        {
            var _dep = _db.Departments.FirstOrDefault(d => d.Id == depId);

            _dep.Name = depvm.DepartmentName;
            _db.SaveChanges();

            return _dep;
        }
    }
}
