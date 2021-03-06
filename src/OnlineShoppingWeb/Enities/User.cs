﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace OnlineShoppingWeb.Enities
{
    public class User : IdentityUser
    {
      
        public string Address { get; set; }
        public DateTime JoinDate { get; set; }
        public virtual ICollection<ShoppingOrder> ShoppingOrders { get; set; }

        public string ShippingAddress { get; set; }

    }
}
