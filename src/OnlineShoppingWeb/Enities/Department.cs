
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingWeb.Enities
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string Description { get; set; }
    }
}
