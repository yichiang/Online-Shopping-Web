using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingWeb.Enities
{
    [Table("ProductReviews")]

    public class ProductReview
    {
        [Key]
        public int ReviewId { get; set; }
        [Range(0, 5)]
        public int Score { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public int ProductId { get; set; }
        public virtual Product Proudct { get; set; }
    }
}
