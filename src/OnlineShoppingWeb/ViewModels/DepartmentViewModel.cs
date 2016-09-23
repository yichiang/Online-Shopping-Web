using OnlineShoppingWeb.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingWeb.ViewModels
{
    public class DepartmentViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<SubDepartment> SubDepartments { get; set; }
        public Department DepartmentOfSub { get; set; }
        public SubDepartment SubDepartment { get; set; }

    }
}
