using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingWeb.Enities
{
    public class SubDepartment
    {
        [Key]
        public int SubDepartmentId { get; set; }
        public string Description { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
