using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_ReactJS.Models;
using WebAPI_ReactJS.ViewModels;

namespace WebAPI_ReactJS.Services.Abstract
{
    public interface IDepartmentServices
    {
        void AddDepartment(DepartmentViewModel depvm);
        DepartmentViewModel GetDepartmentById(int depId);
        List<DepartmentViewModel> GetAllDepartment();
        Department UpdateDepartment(int depId, DepartmentViewModel depvm);
    }
}
