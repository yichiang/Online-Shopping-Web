using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingWeb.Enities
{
    public class ShippingOrder
    {
        public int OrderId { get; set; }
        public string OrderConfirmation { get; set; }
        public DateTime Create_Date { get; set; }
        public string Notes { get; set; }
        public string Payment { get; set; }
        public bool IsShipped { get; set; }
        public bool IsReceived { get; set; }
        public bool IsRequestReturn { get; set; }
    }
}
