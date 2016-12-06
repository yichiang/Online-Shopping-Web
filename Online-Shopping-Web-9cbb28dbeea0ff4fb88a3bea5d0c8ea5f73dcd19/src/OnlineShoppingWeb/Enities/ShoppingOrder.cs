using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingWeb.Enities
{
    public class ShoppingOrder
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderConfirmation { get; set; }
        public DateTime Create_Date { get; set; } = DateTime.UtcNow;
        public string Notes { get; set; }
        public string Payment { get; set; }
        public bool IsShipped { get; set; }
        public bool IsReceived { get; set; }
        public bool IsRequestReturn { get; set; }
   
        public Laptop PurchasedProduct { get; set; }

        public User User { get; set; }
    }
}
