using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingWeb.Enities
{
    public class OrderItem
    {
        public int Qty { get; set; }
        public int ProductId { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}
