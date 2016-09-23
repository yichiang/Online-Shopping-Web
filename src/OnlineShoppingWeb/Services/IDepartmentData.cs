using OnlineShoppingWeb.Enities;
using System.Collections.Generic;

namespace OnlineShoppingWeb.Services
{
    public interface IDepartmentData
    {
        IEnumerable<Department> GetDepartments();
        void AddNewDepartment(Department newDepartment);
    }
}
