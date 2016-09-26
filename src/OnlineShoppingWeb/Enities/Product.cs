
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
        [MaxLength(255)]
        public string Title { get; set; }
        public decimal Price { get; set; }
        public double AvgCustomerReview { get; set; }

    }
}
