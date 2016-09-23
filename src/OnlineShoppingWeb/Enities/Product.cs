
using System.ComponentModel.DataAnnotations;


namespace OnlineShoppingWeb.Enities
{
    public class Product: IProduct
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        public decimal Price { get; set; }
        public double AvgCustomerReview { get; set; }

    }
}
