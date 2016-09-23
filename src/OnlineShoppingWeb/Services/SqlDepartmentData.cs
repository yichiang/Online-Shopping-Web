using OnlineShoppingWeb.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingWeb.Services
{
    public class SqlDepartmentData : IDepartmentData
    {
        private ProductDbContext _context;

        public SqlDepartmentData(ProductDbContext context)
        {
            _context = context;

        }
        public void AddNewDepartment(Department newDepartment)
        {
            Department newDepart = (Department)newDepartment;
            _context.Add(newDepart);
            _context.SaveChanges();
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments.ToList();
        }
    }
}
