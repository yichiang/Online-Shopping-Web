using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingWeb.Enities
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public int Qty { get; set; }
        public int ProductId { get; set; }
        public decimal CurrentPrice { get; set; }
        public int ShoppingOrderId { get; set; }
        public virtual ShoppingOrder ShoppingOrder { get; set; }
        public virtual Product Product { get; set; }

    }
}
