using Microsoft.EntityFrameworkCore;
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

        public void AddNewSubDepartment(SubDepartment newSubDepartment)
        {
            SubDepartment newSubDepart = (SubDepartment)newSubDepartment;
            _context.Add(newSubDepart);
            _context.SaveChanges();
        }

        public Department GetDepartmentById(int DepartmentId)
        {
            return _context.Departments.FirstOrDefault(department => department.DepartmentId == DepartmentId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments.ToList();
        }

        public IEnumerable<SubDepartment> GetSubDepartmentByDepartmentId(int DepartmentId)
        {
            return _context.SubDepartments.Where(subdepartment => subdepartment.Department.DepartmentId == DepartmentId).ToList();
        }
        public IEnumerable<SubDepartment> GetAllSubDepartments() {
            return _context.SubDepartments.ToList();
        }

        public SubDepartment GetSubDepartmentById(int SubDepartmentId)
        {
            return _context.SubDepartments.FirstOrDefault(subdepartment => subdepartment.SubDepartmentId == SubDepartmentId);
        }

        public void EditDepartment(Department editDepartment)
        {
            var oldDepartment =this.GetDepartmentById(editDepartment.DepartmentId);
            oldDepartment.Description = editDepartment.Description;

            _context.SaveChanges();
        }
    }
}
