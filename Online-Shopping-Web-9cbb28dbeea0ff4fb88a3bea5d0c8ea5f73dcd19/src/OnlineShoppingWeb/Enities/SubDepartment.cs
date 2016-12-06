using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingWeb.Enities
{
    [Table("SubDepartments")]
    public class SubDepartment
    {
        [Key]
        public int SubDepartmentId { get; set; }
        public string Description { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
