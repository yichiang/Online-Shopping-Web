using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingWeb.Enities
{
    public class User :IdentityUser
    {
        //[Key]
        //public int UserId { get; set; }
        public string Address { get; set; }
        public DateTime JoinDate { get; set; }
        public virtual ICollection<ShoppingOrder> ShoppingOrders { get; set; }

    }
}
