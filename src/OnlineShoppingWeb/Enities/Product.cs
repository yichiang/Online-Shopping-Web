
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingWeb.Enities
{
    [Table("Products")]
    public class Product: IProduct
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Title { get; set; }
        [Required]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal Price { get; set; }
        public double AvgCustomerReview { get; set; }
        [Required]
        public int SubDepartmentId { get; set; }
        public virtual SubDepartment SubDepartment { get; set; }

    }
}
