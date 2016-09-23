using OnlineShoppingWeb.Enities;
using System.Collections.Generic;

namespace OnlineShoppingWeb.Services
{
    public interface IDepartmentData
    {
        IEnumerable<Department> GetDepartments();
        void AddNewSubDepartment(SubDepartment newSubDepartment);
        void AddNewDepartment(Department newDepartment);
        Department GetDepartmentById(int DepartmentId);
        IEnumerable<SubDepartment> GetSubDepartmentByDepartmentId(int departmentId);
    }
}
