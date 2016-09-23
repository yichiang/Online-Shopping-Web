
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingWeb.Enities
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string Description { get; set; }
    }
}
