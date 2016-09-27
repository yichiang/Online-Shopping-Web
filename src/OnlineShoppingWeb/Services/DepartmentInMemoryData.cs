using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShoppingWeb.Enities;

namespace OnlineShoppingWeb.Services
{
    public class DepartmentInMemoryData : IDepartmentData
    {
        private List<Department> _allDepartment = new List<Department>
        {
            new Department {DepartmentId=1, Description="Electronic" },
            new Department {DepartmentId=2, Description="Clothing" },
            new Department {DepartmentId=3, Description="Home" },
            new Department {DepartmentId=4, Description="Garden" }

        };

        private List<SubDepartment> _allSubDepartment = new List<SubDepartment>
        {
            new SubDepartment {SubDepartmentId=1,DepartmentId=1, Description="Computer" },
            new SubDepartment {SubDepartmentId=2,DepartmentId=1, Description="Phone" },
            new SubDepartment {SubDepartmentId=3,DepartmentId=1, Description="Monitor" },
            new SubDepartment {SubDepartmentId=4,DepartmentId=1, Description="Printer" }

        };
        public void AddNewDepartment(Department newDepartment)
        {
            _allDepartment.Add(newDepartment);
        }

        public void AddNewSubDepartment(SubDepartment newSubDepartment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubDepartment> GetAllSubDepartments()
        {
            return _allSubDepartment;
        }

        public Department GetDepartmentById(int DepartmentId)
        {
            return _allDepartment.FirstOrDefault( d => d.DepartmentId == DepartmentId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _allDepartment;
        }

        public IEnumerable<SubDepartment> GetSubDepartmentByDepartmentId(int departmentId)
        {
            return _allSubDepartment.Where(d => d.DepartmentId == departmentId);
        }

        public SubDepartment GetSubDepartmentById(int SubDepartmentId)
        {
            return _allSubDepartment.FirstOrDefault(d => d.SubDepartmentId == SubDepartmentId);
        }
    }
}
