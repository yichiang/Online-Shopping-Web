using OnlineShoppingWeb.Enities;
using System.Collections.Generic;

namespace OnlineShoppingWeb.ViewModels
{
    public class DepartmentViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public Department Department { get; set; }

        public IEnumerable<SubDepartment> SubDepartments { get; set; }
        public Department DepartmentOfSub { get; set; }
        public SubDepartment SubDepartment { get; set; }

    }
}
