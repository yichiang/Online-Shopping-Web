using System;
using System.Collections.Generic;
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
        public string OrderAddress { get; set; }

        public string Payment { get; set; }
        public bool IsCanceled { get; set; } = false;
        public bool IsShipped { get; set; } = false;
        public bool IsReceived { get; set; } = false;
        public bool IsRequestReturn { get; set; } = false;

        public virtual ICollection<OrderItem> OrderItem { get; set; }
        public virtual User User { get; set; }
    }
}
