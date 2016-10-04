using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingWeb.Enities
{
    public class ShoppingCart
    {
        [Key]
        public int ShoppingCartId { get; set; }
        public DateTime AddToCartDate { get; set; }

        public int ProductId { get; set; }
        public virtual Product Proudct { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
